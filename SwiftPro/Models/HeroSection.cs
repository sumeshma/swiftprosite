using System.ComponentModel.DataAnnotations;

namespace SwiftPro.Models;

public class HeroSection
{
    public int Id { get; set; }

    [Required]
    [MaxLength(300)]
    public string BadgeText { get; set; } = string.Empty;

    [Required]
    [MaxLength(500)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MaxLength(1000)]
    public string Subtitle { get; set; } = string.Empty;

    public string PrimaryButtonText { get; set; } = string.Empty;

    public string PrimaryButtonUrl { get; set; } = string.Empty;

    public string SecondaryButtonText { get; set; } = string.Empty;

    public string SecondaryButtonUrl { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;
}