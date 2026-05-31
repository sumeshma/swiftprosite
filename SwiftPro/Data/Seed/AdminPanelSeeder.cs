using SwiftPro.Models;

namespace SwiftPro.Data.Seed;

public static class AdminPanelSeeder
{
    public static async Task SeedAsync(ApplicationDbContext dbContext)
    {
        var defaultMenuItems = new List<NavigationMenuItem>
        {
            new() { Label = "Home", Url = "/", SortOrder = 10 },
            new() { Label = "About", Url = "/Company/About", SortOrder = 20 },
            new() { Label = "Services", Url = "/Company/Services", SortOrder = 30 },
            new() { Label = "Technologies", Url = "/Company/Technologies", SortOrder = 40 },
            new() { Label = "Portfolio", Url = "/Company/Portfolio", SortOrder = 50 },
            new() { Label = "Xersio", Url = "/Company/Xersio", SortOrder = 55 },
            new() { Label = "Careers", Url = "/Company/Careers", SortOrder = 60 },
            new() { Label = "Contact Us", Url = "/Contact", SortOrder = 70, IsButton = true }
        };

        foreach (var menuItem in defaultMenuItems)
        {
            if (!dbContext.NavigationMenuItems.Any(x => x.Url == menuItem.Url))
                dbContext.NavigationMenuItems.Add(menuItem);
        }

        if (!dbContext.SiteSettings.Any())
        {
            dbContext.SiteSettings.Add(new SiteSetting
            {
                SiteName = "SwiftPro Solutions",
                LogoUrl = "/images/swiftpro-logo-header.png",
                HeaderLogoWidth = 220,
                FooterLogoUrl = "/images/swiftpro-logo-full-cropped.png",
                FooterLogoWidth = 180,
                ContactEmail = "hello@swiftprosolutions.com",
                ContactPhone = "+91 90000 00000",
                SendContactEmails = false,
                SmtpPort = 587,
                SmtpEnableSsl = true,
                UseSingleHomePageBackground = true,
                HomePageSectionTransparency = 10,
                ShowSocialIconsInHeader = true,
                ShowSocialIconsInFooter = true,
                FooterCompanyHeading = "Company",
                FooterResourcesHeading = "Resources",
                FooterBottomText = "Built with ASP.NET Core MVC + PostgreSQL",
                FooterText = "We craft premium digital products and enterprise-grade solutions for ambitious organizations worldwide."
            });
        }
        else
        {
            var settings = dbContext.SiteSettings.First();

            settings.LogoUrl = "/images/swiftpro-logo-header.png";
            settings.HeaderLogoWidth = settings.HeaderLogoWidth is < 180 or > 320
                ? 220
                : Math.Max(settings.HeaderLogoWidth, 220);
            settings.FooterLogoUrl = string.IsNullOrWhiteSpace(settings.FooterLogoUrl)
                ? "/images/swiftpro-logo-full-cropped.png"
                : settings.FooterLogoUrl;
            settings.FooterCompanyHeading = string.IsNullOrWhiteSpace(settings.FooterCompanyHeading)
                ? "Company"
                : settings.FooterCompanyHeading;
            settings.FooterResourcesHeading = string.IsNullOrWhiteSpace(settings.FooterResourcesHeading)
                ? "Resources"
                : settings.FooterResourcesHeading;
            settings.FooterBottomText = string.IsNullOrWhiteSpace(settings.FooterBottomText)
                ? "Built with ASP.NET Core MVC + PostgreSQL"
                : settings.FooterBottomText;
            settings.UpdatedAt = DateTime.UtcNow;
        }

        await dbContext.SaveChangesAsync();
    }
}
