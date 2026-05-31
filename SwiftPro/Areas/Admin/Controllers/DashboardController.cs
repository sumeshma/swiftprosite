using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftPro.Data;

namespace SwiftPro.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin,Editor,Manager")]
public class DashboardController(ApplicationDbContext dbContext) : Controller
{
    public async Task<IActionResult> Index()
    {
        ViewBag.TotalPages = await dbContext.Pages.CountAsync();
        ViewBag.PublishedPages = await dbContext.Pages.CountAsync(x => x.IsPublished);
        ViewBag.TotalContacts = await dbContext.ContactMessages.CountAsync();
        ViewBag.UnreadContacts = await dbContext.ContactMessages.CountAsync(x => !x.IsRead);
        ViewBag.TotalMenus = await dbContext.NavigationMenuItems.CountAsync();
        ViewBag.TotalMedia = await dbContext.MediaAssets.CountAsync();
        ViewBag.RecentPages = await dbContext.Pages
            .OrderByDescending(x => x.UpdatedAt ?? x.CreatedAt)
            .Take(5)
            .ToListAsync();
        ViewBag.RecentContacts = await dbContext.ContactMessages
            .OrderByDescending(x => x.CreatedUtc)
            .Take(5)
            .ToListAsync();

        return View();
    }
}
