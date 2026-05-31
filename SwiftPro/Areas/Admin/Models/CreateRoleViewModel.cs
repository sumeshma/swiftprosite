using System.ComponentModel.DataAnnotations;

namespace SwiftPro.Areas.Admin.Models;

public class CreateRoleViewModel
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
}
