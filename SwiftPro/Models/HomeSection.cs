using System.ComponentModel.DataAnnotations;

namespace SwiftPro.Models;

public class HomeSection
{
    public int Id { get; set; }

    [Required]
    public string SectionKey { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Subtitle { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public string ButtonText { get; set; } = string.Empty;

    public string ButtonUrl { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;
}