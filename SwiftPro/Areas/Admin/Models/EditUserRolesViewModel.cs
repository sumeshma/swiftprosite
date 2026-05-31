using System.ComponentModel.DataAnnotations;

namespace SwiftPro.Areas.Admin.Models;

public class EditUserRolesViewModel
{
    [Required]
    public string UserId { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public bool IsActive { get; set; }

    public List<string> SelectedRoles { get; set; } = [];

    public List<string> AvailableRoles { get; set; } = [];
}
