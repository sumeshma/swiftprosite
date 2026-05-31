using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftPro.Data;
using SwiftPro.Models;
using System.Text.RegularExpressions;

namespace SwiftPro.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin,Editor")]
public class PagesController(ApplicationDbContext dbContext) : Controller
{
    public async Task<IActionResult> Index()
    {
        var pages = await dbContext.Pages
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();

        return View(pages);
    }

    public IActionResult Create()
    {
        return View(new CmsPage { IsPublished = true });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CmsPage model)
    {
        model.Slug = GenerateSlug(string.IsNullOrWhiteSpace(model.Slug)
            ? model.Title
            : model.Slug);
        ModelState.Remove(nameof(CmsPage.Slug));

        if (!ModelState.IsValid)
            return View(model);

        if (await dbContext.Pages.AnyAsync(x => x.Slug == model.Slug))
        {
            ModelState.AddModelError(nameof(CmsPage.Slug), "A page with this slug already exists.");
            return View(model);
        }

        model.CreatedAt = DateTime.UtcNow;

        dbContext.Pages.Add(model);

        await dbContext.SaveChangesAsync();

        TempData["Success"] = "Page created successfully.";

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var page = await dbContext.Pages.FindAsync(id);

        if (page == null)
            return NotFound();

        return View(page);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(CmsPage model)
    {
        model.Slug = GenerateSlug(string.IsNullOrWhiteSpace(model.Slug)
            ? model.Title
            : model.Slug);

        if (!ModelState.IsValid)
            return View(model);

        if (await dbContext.Pages.AnyAsync(x => x.Id != model.Id && x.Slug == model.Slug))
        {
            ModelState.AddModelError(nameof(CmsPage.Slug), "A page with this slug already exists.");
            return View(model);
        }

        var page = await dbContext.Pages.FindAsync(model.Id);

        if (page == null)
            return NotFound();

        page.Title = model.Title;
        page.Slug = model.Slug;
        page.Content = model.Content;
        page.MetaTitle = model.MetaTitle;
        page.MetaDescription = model.MetaDescription;
        page.IsPublished = model.IsPublished;
        page.UpdatedAt = DateTime.UtcNow;

        await dbContext.SaveChangesAsync();

        TempData["Success"] = "Page updated successfully.";

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var page = await dbContext.Pages.FindAsync(id);

        if (page == null)
            return NotFound();

        dbContext.Pages.Remove(page);

        await dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    private static string GenerateSlug(string text)
    {
        var slug = Regex.Replace(text.Trim().ToLowerInvariant(), @"[^a-z0-9]+", "-");
        return slug.Trim('-');
    }
}
