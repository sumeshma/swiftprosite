namespace SwiftPro.Areas.Admin.Models;

public class HomePagePageSettingViewModel
{
    public int PageId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public bool IsPublished { get; set; }

    public bool ShowOnHomePage { get; set; }

    public int HomePageSortOrder { get; set; }

    public string? HomePageAnchor { get; set; }
}
