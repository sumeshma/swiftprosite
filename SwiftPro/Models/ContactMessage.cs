using System.ComponentModel.DataAnnotations;

namespace SwiftPro.Models;

public class ContactMessage
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [MaxLength(150)]
    public string Email { get; set; } = string.Empty;

    [MaxLength(20)]
    public string? CountryCode { get; set; }

    [MaxLength(60)]
    public string? PhoneNumber { get; set; }

    [MaxLength(100)]
    public string? Country { get; set; }

    [Required]
    [MaxLength(150)]
    public string Subject { get; set; } = string.Empty;

    [Required]
    [MaxLength(2500)]
    public string Message { get; set; } = string.Empty;

    public DateTime CreatedUtc { get; set; }

    public bool IsRead { get; set; }

    [MaxLength(40)]
    public string Status { get; set; } = "New";

    [MaxLength(40)]
    public string? LastReplyChannel { get; set; }

    public DateTime? LastRepliedAt { get; set; }

    [MaxLength(1000)]
    public string? AdminNotes { get; set; }
}
