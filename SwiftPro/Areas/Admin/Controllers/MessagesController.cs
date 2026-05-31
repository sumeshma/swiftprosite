using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftPro.Areas.Admin.Models;
using SwiftPro.Data;
using SwiftPro.Models;

namespace SwiftPro.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin,Manager")]
public class MessagesController(ApplicationDbContext dbContext) : Controller
{
    public async Task<IActionResult> Index(string? status)
    {
        var messages = dbContext.ContactMessages.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(status))
            messages = messages.Where(x => x.Status == status);

        ViewBag.Status = status;

        return View(await messages
            .OrderByDescending(x => x.CreatedUtc)
            .ToListAsync());
    }

    public async Task<IActionResult> Details(int id)
    {
        var message = await dbContext.ContactMessages.FindAsync(id);

        if (message == null)
            return NotFound();

        if (!message.IsRead)
        {
            message.IsRead = true;
            await dbContext.SaveChangesAsync();
        }

        var settings = await dbContext.SiteSettings.AsNoTracking().FirstOrDefaultAsync()
            ?? new SiteSetting();

        return View(new MessageDetailsViewModel
        {
            Message = message,
            SiteSetting = settings,
            EmailReplyUrl = BuildMailto(message),
            WhatsAppReplyUrl = BuildWhatsApp(settings, message)
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateStatus(int id, string status, string? adminNotes)
    {
        var message = await dbContext.ContactMessages.FindAsync(id);

        if (message == null)
            return NotFound();

        message.Status = string.IsNullOrWhiteSpace(status) ? message.Status : status;
        message.AdminNotes = adminNotes;
        message.IsRead = true;

        await dbContext.SaveChangesAsync();

        TempData["Success"] = "Message updated successfully.";
        return RedirectToAction(nameof(Details), new { id });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> TrackReply(int id, string channel)
    {
        var message = await dbContext.ContactMessages.FindAsync(id);

        if (message == null)
            return NotFound();

        message.LastReplyChannel = channel;
        message.LastRepliedAt = DateTime.UtcNow;
        message.Status = "Replied";
        message.IsRead = true;

        await dbContext.SaveChangesAsync();

        return Ok();
    }

    private static string BuildMailto(ContactMessage message)
    {
        var subject = Uri.EscapeDataString($"Re: {message.Subject}");
        var body = Uri.EscapeDataString($"""
Hi {message.Name},

Thank you for contacting SwiftPro Solutions.


Regards,
SwiftPro Solutions
""");

        return $"mailto:{message.Email}?subject={subject}&body={body}";
    }

    private static string? BuildWhatsApp(SiteSetting settings, ContactMessage message)
    {
        if (string.IsNullOrWhiteSpace(settings.WhatsAppNumber))
            return null;

        var number = new string(settings.WhatsAppNumber.Where(char.IsDigit).ToArray());

        if (string.IsNullOrWhiteSpace(number))
            return null;

        var text = Uri.EscapeDataString($"Hi {message.Name}, thanks for contacting SwiftPro Solutions about {message.Subject}.");
        return $"https://wa.me/{number}?text={text}";
    }
}
