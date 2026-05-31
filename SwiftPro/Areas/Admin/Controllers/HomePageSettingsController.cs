using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftPro.Areas.Admin.Models;
using SwiftPro.Data;
using System.Text.RegularExpressions;

namespace SwiftPro.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin,Editor")]
public class HomePageSettingsController(ApplicationDbContext dbContext) : Controller
{
    public async Task<IActionResult> Index()
    {
        return View(await BuildModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(HomePageSettingsViewModel model)
    {
        var pageIds = model.Pages.Select(x => x.PageId).ToList();
        var pages = await dbContext.Pages
            .Where(x => pageIds.Contains(x.Id))
            .ToListAsync();

        foreach (var page in pages)
        {
            var setting = model.Pages.First(x => x.PageId == page.Id);
            page.ShowOnHomePage = setting.ShowOnHomePage;
            page.HomePageSortOrder = setting.HomePageSortOrder;
            page.HomePageAnchor = GenerateAnchor(string.IsNullOrWhiteSpace(setting.HomePageAnchor)
                ? page.Slug
                : setting.HomePageAnchor);
            page.UpdatedAt = DateTime.UtcNow;
        }

        await dbContext.SaveChangesAsync();

        TempData["Success"] = "Home page settings saved successfully.";
        return RedirectToAction(nameof(Index));
    }

    private async Task<HomePageSettingsViewModel> BuildModel()
    {
        var pages = await dbContext.Pages
            .AsNoTracking()
            .OrderBy(x => x.HomePageSortOrder)
            .ThenBy(x => x.Title)
            .ToListAsync();

        return new HomePageSettingsViewModel
        {
            Pages = pages.Select(page => new HomePagePageSettingViewModel
            {
                PageId = page.Id,
                Title = page.Title,
                Slug = page.Slug,
                IsPublished = page.IsPublished,
                ShowOnHomePage = page.ShowOnHomePage,
                HomePageSortOrder = page.HomePageSortOrder,
                HomePageAnchor = string.IsNullOrWhiteSpace(page.HomePageAnchor) ? page.Slug : page.HomePageAnchor
            }).ToList()
        };
    }

    private static string GenerateAnchor(string text)
    {
        var anchor = Regex.Replace(text.Trim().ToLowerInvariant(), @"[^a-z0-9]+", "-");
        return anchor.Trim('-');
    }
}
