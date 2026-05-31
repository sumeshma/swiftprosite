
using Microsoft.AspNetCore.Identity;

namespace SwiftPro.Models.Identity;

public class ApplicationUser : IdentityUser
{
    public string? FullName { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}