namespace SwiftPro.Models.ViewModels;

public class HomePageViewModel
{
    public HeroSection? Hero { get; set; }

    public CmsPage? Page { get; set; }

    public IReadOnlyList<CmsPage> IncludedPages { get; set; } = [];

    public SiteSetting? SiteSetting { get; set; }
}
