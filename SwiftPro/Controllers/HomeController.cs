using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftPro.Data;
using SwiftPro.Models;
using SwiftPro.Models.ViewModels;
using System.Diagnostics;

namespace SwiftPro.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _dbContext;

    public HomeController(
        ILogger<HomeController> logger,
        ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public async Task<IActionResult> Index()
    {
        var hero = await _dbContext.HeroSections
            .Where(x => x.IsActive)
            .OrderByDescending(x => x.Id)
            .FirstOrDefaultAsync();

        var page = await _dbContext.Pages
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Slug == "home" && x.IsPublished);

        var siteSetting = await _dbContext.SiteSettings
            .AsNoTracking()
            .FirstOrDefaultAsync();

        var includedPages = await _dbContext.Pages
            .AsNoTracking()
            .Where(x => x.IsPublished && x.ShowOnHomePage && x.Slug != "home")
            .OrderBy(x => x.HomePageSortOrder)
            .ThenBy(x => x.Title)
            .ToListAsync();

        ViewData["Title"] = page?.MetaTitle ?? page?.Title ?? "SwiftPro Solutions";
        ViewData["MetaDescription"] = page?.MetaDescription
            ?? "SwiftPro Solutions is a modern software company delivering scalable digital products and enterprise solutions.";

        return View(new HomePageViewModel
        {
            Hero = hero,
            Page = page,
            IncludedPages = includedPages,
            SiteSetting = siteSetting
        });
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(
        Duration = 0,
        Location = ResponseCacheLocation.None,
        NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel
            {
                RequestId =
                    Activity.Current?.Id
                    ?? HttpContext.TraceIdentifier
            });
    }
}
