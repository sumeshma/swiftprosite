using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftPro.Data;
using SwiftPro.Models.ViewModels;
using SwiftPro.Services;

namespace SwiftPro.Controllers;

public class ContactController(
    IContactService contactService,
    ILogger<ContactController> logger,
    ApplicationDbContext dbContext) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        await SetContactPageData();
        return View(new ContactFormViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(ContactFormViewModel model, CancellationToken cancellationToken)
    {
        await SetContactPageData();

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            await contactService.SaveMessageAsync(model, cancellationToken);
            TempData["SuccessMessage"] = "Thank you for reaching out. Our team will connect with you shortly.";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to save contact message from {Email}", model.Email);
            ModelState.AddModelError(string.Empty, "Something went wrong while sending your message. Please try again.");
            return View(model);
        }
    }

    private async Task SetContactPageData()
    {
        var page = await dbContext.Pages
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Slug == "contact" && x.IsPublished);

        ViewData["Title"] = page?.MetaTitle ?? page?.Title ?? "Contact Us";
        ViewData["MetaDescription"] = page?.MetaDescription
            ?? "Get in touch with SwiftPro Solutions for software consulting, product development, and technical partnership.";
        ViewData["PageContent"] = page?.Content;
    }
}
