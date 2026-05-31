using System.ComponentModel.DataAnnotations;

namespace SwiftPro.Areas.Admin.Models;

public class CreateUserViewModel
{
    [Required]
    [MaxLength(150)]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [MaxLength(150)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MinLength(6)]
    public string Password { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public List<string> SelectedRoles { get; set; } = [];

    public List<string> AvailableRoles { get; set; } = [];
}
