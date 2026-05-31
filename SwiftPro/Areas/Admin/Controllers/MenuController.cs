using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftPro.Data;
using SwiftPro.Models;

namespace SwiftPro.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin,Editor")]
public class MenuController(ApplicationDbContext dbContext) : Controller
{
    public async Task<IActionResult> Index()
    {
        var items = await dbContext.NavigationMenuItems
            .OrderBy(x => x.SortOrder)
            .ThenBy(x => x.Label)
            .ToListAsync();

        return View(items);
    }

    public IActionResult Create()
    {
        return View(new NavigationMenuItem
        {
            IsActive = true,
            SortOrder = 100
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(NavigationMenuItem model)
    {
        if (!ModelState.IsValid)
            return View(model);

        model.CreatedAt = DateTime.UtcNow;
        dbContext.NavigationMenuItems.Add(model);
        await dbContext.SaveChangesAsync();

        TempData["Success"] = "Menu item created successfully.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var item = await dbContext.NavigationMenuItems.FindAsync(id);

        if (item == null)
            return NotFound();

        return View(item);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(NavigationMenuItem model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var item = await dbContext.NavigationMenuItems.FindAsync(model.Id);

        if (item == null)
            return NotFound();

        item.Label = model.Label;
        item.Url = model.Url;
        item.IconClass = model.IconClass;
        item.SortOrder = model.SortOrder;
        item.OpenInNewTab = model.OpenInNewTab;
        item.IsButton = model.IsButton;
        item.IsActive = model.IsActive;
        item.UpdatedAt = DateTime.UtcNow;

        await dbContext.SaveChangesAsync();

        TempData["Success"] = "Menu item updated successfully.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await dbContext.NavigationMenuItems.FindAsync(id);

        if (item == null)
            return NotFound();

        dbContext.NavigationMenuItems.Remove(item);
        await dbContext.SaveChangesAsync();

        TempData["Success"] = "Menu item deleted successfully.";
        return RedirectToAction(nameof(Index));
    }
}
