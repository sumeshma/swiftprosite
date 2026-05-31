using System.ComponentModel.DataAnnotations;

namespace SwiftPro.Models;

public class SiteSetting
{
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string SiteName { get; set; } = "SwiftPro Solutions";

    [MaxLength(500)]
    public string? LogoUrl { get; set; }

    public int HeaderLogoWidth { get; set; } = 180;

    [MaxLength(500)]
    public string? FooterLogoUrl { get; set; }

    public int FooterLogoWidth { get; set; } = 180;

    [MaxLength(500)]
    public string? FaviconUrl { get; set; }

    [MaxLength(500)]
    public string? DefaultThumbnailUrl { get; set; }

    [MaxLength(500)]
    public string? HeroBackgroundImageUrl { get; set; }

    public bool UseSingleHomePageBackground { get; set; } = true;

    [Range(0, 100)]
    public int HomePageSectionTransparency { get; set; } = 10;

    [MaxLength(150)]
    public string? ContactEmail { get; set; }

    [MaxLength(60)]
    public string? ContactPhone { get; set; }

    public bool SendContactEmails { get; set; }

    [MaxLength(150)]
    public string? SmtpHost { get; set; }

    public int SmtpPort { get; set; } = 587;

    public bool SmtpEnableSsl { get; set; } = true;

    [MaxLength(150)]
    public string? SmtpUsername { get; set; }

    [MaxLength(500)]
    public string? SmtpPassword { get; set; }

    [MaxLength(150)]
    public string? SmtpFromEmail { get; set; }

    [MaxLength(60)]
    public string? WhatsAppNumber { get; set; }

    [MaxLength(500)]
    public string? FacebookUrl { get; set; }

    [MaxLength(500)]
    public string? InstagramUrl { get; set; }

    [MaxLength(500)]
    public string? LinkedInUrl { get; set; }

    [MaxLength(500)]
    public string? XUrl { get; set; }

    public bool ShowSocialIconsInHeader { get; set; } = true;

    public bool ShowSocialIconsInFooter { get; set; } = true;

    [MaxLength(80)]
    public string? FooterCompanyHeading { get; set; } = "Company";

    public string? FooterCompanyLinksHtml { get; set; }

    [MaxLength(80)]
    public string? FooterResourcesHeading { get; set; } = "Resources";

    public string? FooterResourcesLinksHtml { get; set; }

    [MaxLength(180)]
    public string? FooterBottomText { get; set; }

    [MaxLength(500)]
    public string? FooterText { get; set; }

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
