using System.ComponentModel.DataAnnotations;

namespace SwiftPro.Areas.Admin.Models;

public class ChangeUserPasswordViewModel
{
    [Required]
    public string UserId { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    [Required]
    [MinLength(6)]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [Compare(nameof(NewPassword), ErrorMessage = "Password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
