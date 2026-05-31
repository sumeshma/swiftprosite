using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftPro.Data;

namespace SwiftPro.Controllers;

public class CompanyController(ApplicationDbContext dbContext) : Controller
{
    public Task<IActionResult> About()
    {
        return PageBySlug("about", "About Us",
            "Learn about SwiftPro Solutions, our mission, values, and software delivery approach.");
    }

    public Task<IActionResult> Services()
    {
        return PageBySlug("services", "Services",
            "Explore SwiftPro Solutions software services including custom product development, modernization, and support.");
    }

    public Task<IActionResult> Technologies()
    {
        return PageBySlug("technologies", "Technologies",
            "Discover technologies and platforms used by SwiftPro Solutions for modern product engineering.");
    }

    public Task<IActionResult> Portfolio()
    {
        return PageBySlug("portfolio", "Portfolio",
            "See selected SwiftPro Solutions projects and delivery outcomes across industries.");
    }

    public Task<IActionResult> Corefit()
    {
        return PageBySlug("corefit", "Corefit | Gym Management Software",
            "Corefit is a gym management software platform built by SwiftPro Solutions for membership, billing, attendance, and analytics.");
    }

    public Task<IActionResult> Xersio()
    {
        return PageBySlug("xersio", "Xersio | Gym Management Software",
            "Xersio is a gym management software platform built by SwiftPro Solutions for membership, billing, attendance, and analytics.");
    }

    public Task<IActionResult> Careers()
    {
        return PageBySlug("careers", "Careers",
            "Join SwiftPro Solutions and build high-impact products with a modern engineering team.");
    }

    private async Task<IActionResult> PageBySlug(
        string slug,
        string fallbackTitle,
        string fallbackMetaDescription)
    {
        var page = await dbContext.Pages
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Slug == slug && x.IsPublished);

        if (page == null)
            return NotFound();

        ViewData["Title"] = page.MetaTitle ?? page.Title ?? fallbackTitle;
        ViewData["MetaDescription"] = page.MetaDescription ?? fallbackMetaDescription;

        return View(page);
    }
}
