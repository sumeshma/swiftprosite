using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftPro.Data;
using SwiftPro.Models;

namespace SwiftPro.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin,Editor")]
public class HeroSectionController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public HeroSectionController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var hero = await _dbContext.HeroSections
            .OrderByDescending(x => x.Id)
            .FirstOrDefaultAsync();

        if (hero == null)
        {
            hero = new HeroSection
            {
                BadgeText = "",
                Title = "",
                Subtitle = "",
                PrimaryButtonText = "",
                PrimaryButtonUrl = "",
                SecondaryButtonText = "",
                SecondaryButtonUrl = ""
            };

            _dbContext.HeroSections.Add(hero);

            await _dbContext.SaveChangesAsync();
        }

        return View(hero);
    }

    // POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(HeroSection model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var hero = await _dbContext.HeroSections
            .FirstOrDefaultAsync(x => x.Id == model.Id);

        if (hero == null)
        {
            hero = new HeroSection();

            _dbContext.HeroSections.Add(hero);
        }

        hero.BadgeText = model.BadgeText;
        hero.Title = model.Title;
        hero.Subtitle = model.Subtitle;
        hero.PrimaryButtonText = model.PrimaryButtonText;
        hero.PrimaryButtonUrl = model.PrimaryButtonUrl;
        hero.SecondaryButtonText = model.SecondaryButtonText;
        hero.SecondaryButtonUrl = model.SecondaryButtonUrl;

        await _dbContext.SaveChangesAsync();

        TempData["Success"] = "Hero section updated successfully.";

        return RedirectToAction(nameof(Index));
    }
}
