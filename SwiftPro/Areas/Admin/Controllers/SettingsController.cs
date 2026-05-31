using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftPro.Data;
using SwiftPro.Models;

namespace SwiftPro.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin,Editor")]
public class SettingsController(
    ApplicationDbContext dbContext,
    IWebHostEnvironment environment) : Controller
{
    public async Task<IActionResult> Index()
    {
        return View(await GetSettings());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(
        SiteSetting model,
        IFormFile? logoFile,
        IFormFile? heroBackgroundFile)
    {
        if (!ModelState.IsValid)
            return View(model);

        var settings = await GetSettings();

        settings.SiteName = model.SiteName;
        settings.ContactEmail = model.ContactEmail;
        settings.ContactPhone = model.ContactPhone;
        settings.SendContactEmails = model.SendContactEmails;
        settings.SmtpHost = model.SmtpHost;
        settings.SmtpPort = model.SmtpPort;
        settings.SmtpEnableSsl = model.SmtpEnableSsl;
        settings.SmtpUsername = model.SmtpUsername;
        settings.SmtpFromEmail = model.SmtpFromEmail;
        if (!string.IsNullOrWhiteSpace(model.SmtpPassword))
            settings.SmtpPassword = model.SmtpPassword;
        settings.WhatsAppNumber = model.WhatsAppNumber;
        settings.FacebookUrl = model.FacebookUrl;
        settings.InstagramUrl = model.InstagramUrl;
        settings.LinkedInUrl = model.LinkedInUrl;
        settings.XUrl = model.XUrl;
        settings.FooterText = model.FooterText;
        settings.HeaderLogoWidth = model.HeaderLogoWidth;
        settings.FooterLogoWidth = model.FooterLogoWidth;
        settings.FaviconUrl = model.FaviconUrl;
        settings.DefaultThumbnailUrl = model.DefaultThumbnailUrl;
        settings.UseSingleHomePageBackground = model.UseSingleHomePageBackground;
        settings.HomePageSectionTransparency = Math.Clamp(model.HomePageSectionTransparency, 0, 100);
        settings.LogoUrl = logoFile is { Length: > 0 }
            ? await SaveImage(logoFile)
            : model.LogoUrl;
        settings.FooterLogoUrl = model.FooterLogoUrl;
        settings.HeroBackgroundImageUrl = heroBackgroundFile is { Length: > 0 }
            ? await SaveImage(heroBackgroundFile)
            : model.HeroBackgroundImageUrl;
        settings.UpdatedAt = DateTime.UtcNow;

        await dbContext.SaveChangesAsync();

        TempData["Success"] = "Appearance settings saved successfully.";
        return RedirectToAction(nameof(Index));
    }

    private async Task<SiteSetting> GetSettings()
    {
        var settings = await dbContext.SiteSettings.FirstOrDefaultAsync();

        if (settings != null)
            return settings;

        settings = new SiteSetting();
        dbContext.SiteSettings.Add(settings);
        await dbContext.SaveChangesAsync();

        return settings;
    }

    private async Task<string> SaveImage(IFormFile file)
    {
        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp", ".gif" };

        if (!allowedExtensions.Contains(extension))
            throw new InvalidOperationException("Only JPG, PNG, WEBP, and GIF files are allowed.");

        var uploadsRoot = Path.Combine(environment.WebRootPath, "uploads", "site");
        Directory.CreateDirectory(uploadsRoot);

        var fileName = $"{Guid.NewGuid():N}{extension}";
        var fullPath = Path.Combine(uploadsRoot, fileName);

        await using var stream = System.IO.File.Create(fullPath);
        await file.CopyToAsync(stream);

        return $"/uploads/site/{fileName}";
    }
}
