using System.ComponentModel.DataAnnotations;

namespace SwiftPro.Models;

public class NavigationMenuItem
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Label { get; set; } = string.Empty;

    [Required]
    [MaxLength(500)]
    public string Url { get; set; } = string.Empty;

    [MaxLength(50)]
    public string? IconClass { get; set; }

    public int SortOrder { get; set; }

    public bool OpenInNewTab { get; set; }

    public bool IsButton { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }
}
