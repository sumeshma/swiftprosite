namespace SwiftPro.Areas.Admin.Models;

public class UserListItemViewModel
{
    public string Id { get; set; } = string.Empty;

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public IList<string> Roles { get; set; } = [];
}
