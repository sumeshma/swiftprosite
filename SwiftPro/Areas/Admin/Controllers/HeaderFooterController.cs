using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftPro.Data;
using SwiftPro.Models;

namespace SwiftPro.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin,Editor")]
public class HeaderFooterController(ApplicationDbContext dbContext) : Controller
{
    public async Task<IActionResult> Index()
    {
        return View(await GetSettings());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(SiteSetting model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var settings = await GetSettings();

        settings.SiteName = model.SiteName;
        settings.LogoUrl = model.LogoUrl;
        settings.HeaderLogoWidth = model.HeaderLogoWidth;
        settings.FooterLogoUrl = model.FooterLogoUrl;
        settings.FooterLogoWidth = model.FooterLogoWidth;
        settings.ContactEmail = model.ContactEmail;
        settings.ContactPhone = model.ContactPhone;
        settings.WhatsAppNumber = model.WhatsAppNumber;
        settings.FacebookUrl = model.FacebookUrl;
        settings.InstagramUrl = model.InstagramUrl;
        settings.LinkedInUrl = model.LinkedInUrl;
        settings.XUrl = model.XUrl;
        settings.ShowSocialIconsInHeader = model.ShowSocialIconsInHeader;
        settings.ShowSocialIconsInFooter = model.ShowSocialIconsInFooter;
        settings.FooterText = model.FooterText;
        settings.FooterCompanyHeading = model.FooterCompanyHeading;
        settings.FooterCompanyLinksHtml = model.FooterCompanyLinksHtml;
        settings.FooterResourcesHeading = model.FooterResourcesHeading;
        settings.FooterResourcesLinksHtml = model.FooterResourcesLinksHtml;
        settings.FooterBottomText = model.FooterBottomText;
        settings.UpdatedAt = DateTime.UtcNow;

        await dbContext.SaveChangesAsync();

        TempData["Success"] = "Header and footer settings saved successfully.";
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
}
