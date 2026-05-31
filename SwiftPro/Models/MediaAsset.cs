using System.ComponentModel.DataAnnotations;

namespace SwiftPro.Models;

public class MediaAsset
{
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string UsageType { get; set; } = "Page";

    [Required]
    [MaxLength(500)]
    public string Url { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? AltText { get; set; }

    [MaxLength(150)]
    public string? OriginalFileName { get; set; }

    public long FileSizeBytes { get; set; }

    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
}
