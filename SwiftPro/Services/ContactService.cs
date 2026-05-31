using SwiftPro.Data;
using SwiftPro.Models;
using SwiftPro.Models.ViewModels;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace SwiftPro.Services;

public class ContactService(
    ApplicationDbContext dbContext,
    ILogger<ContactService> logger) : IContactService
{
    public async Task SaveMessageAsync(ContactFormViewModel model, CancellationToken cancellationToken = default)
    {
        var message = new ContactMessage
        {
            Name = model.Name.Trim(),
            Email = model.Email.Trim(),
            CountryCode = model.CountryCode.Trim(),
            PhoneNumber = model.PhoneNumber.Trim(),
            Country = model.Country.Trim(),
            Subject = model.Subject.Trim(),
            Message = model.Message.Trim(),
            CreatedUtc = DateTime.UtcNow
        };

        await dbContext.ContactMessages.AddAsync(message, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        await SendEmailNotificationAsync(message, cancellationToken);
    }

    private async Task SendEmailNotificationAsync(ContactMessage message, CancellationToken cancellationToken)
    {
        var settings = dbContext.SiteSettings.FirstOrDefault();

        if (settings is not { SendContactEmails: true } ||
            string.IsNullOrWhiteSpace(settings.ContactEmail) ||
            string.IsNullOrWhiteSpace(settings.SmtpHost) ||
            settings.SmtpPort <= 0)
        {
            return;
        }

        try
        {
            using var mail = new MailMessage
            {
                From = new MailAddress(GetFromAddress(settings)),
                Subject = $"New contact message: {message.Subject}",
                Body = BuildEmailBody(message),
                IsBodyHtml = false
            };

            mail.To.Add(settings.ContactEmail.Trim());
            mail.ReplyToList.Add(new MailAddress(message.Email, message.Name));

            using var smtpClient = new SmtpClient(settings.SmtpHost.Trim(), settings.SmtpPort)
            {
                EnableSsl = settings.SmtpEnableSsl
            };

            if (!string.IsNullOrWhiteSpace(settings.SmtpUsername))
            {
                smtpClient.Credentials = new NetworkCredential(
                    settings.SmtpUsername.Trim(),
                    settings.SmtpPassword ?? string.Empty);
            }

            await smtpClient.SendMailAsync(mail, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to email contact message {MessageId} to {ContactEmail}", message.Id, settings.ContactEmail);
        }
    }

    private static string GetFromAddress(SiteSetting settings)
    {
        if (!string.IsNullOrWhiteSpace(settings.SmtpFromEmail))
            return settings.SmtpFromEmail.Trim();

        if (!string.IsNullOrWhiteSpace(settings.SmtpUsername))
            return settings.SmtpUsername.Trim();

        return settings.ContactEmail?.Trim() ?? "no-reply@swiftpro.local";
    }

    private static string BuildEmailBody(ContactMessage message)
    {
        var builder = new StringBuilder();
        builder.AppendLine("A new message was submitted from the website contact page.");
        builder.AppendLine();
        builder.AppendLine($"Name: {message.Name}");
        builder.AppendLine($"Email: {message.Email}");
        builder.AppendLine($"Phone: {message.CountryCode} {message.PhoneNumber}");
        builder.AppendLine($"Country: {message.Country}");
        builder.AppendLine($"Subject: {message.Subject}");
        builder.AppendLine($"Received UTC: {message.CreatedUtc:yyyy-MM-dd HH:mm}");
        builder.AppendLine();
        builder.AppendLine("Message:");
        builder.AppendLine(message.Message);

        return builder.ToString();
    }
}
