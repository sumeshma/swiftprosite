using System.ComponentModel.DataAnnotations;

namespace SwiftPro.Models;

public class CmsPage
{
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MaxLength(250)]
    public string Slug { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    [MaxLength(300)]
    public string? MetaTitle { get; set; }

    [MaxLength(500)]
    public string? MetaDescription { get; set; }

    public bool IsPublished { get; set; } = true;

    public bool ShowOnHomePage { get; set; }

    public int HomePageSortOrder { get; set; } = 100;

    [MaxLength(100)]
    public string? HomePageAnchor { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }
}
