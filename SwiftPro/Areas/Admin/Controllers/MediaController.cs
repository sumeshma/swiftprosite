using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftPro.Data;
using SwiftPro.Models;

namespace SwiftPro.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin,Editor")]
public class MediaController(
    ApplicationDbContext dbContext,
    IWebHostEnvironment environment) : Controller
{
    private static readonly string[] AllowedExtensions = [".jpg", ".jpeg", ".png", ".webp", ".gif", ".svg", ".ico"];

    public async Task<IActionResult> Index(string? usageType)
    {
        var assets = dbContext.MediaAssets.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(usageType))
            assets = assets.Where(x => x.UsageType == usageType);

        ViewBag.UsageType = usageType;

        return View(await assets
            .OrderByDescending(x => x.UploadedAt)
            .ToListAsync());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Upload(
        string title,
        string usageType,
        string? altText,
        IFormFile imageFile)
    {
        if (imageFile == null || imageFile.Length == 0)
        {
            TempData["Error"] = "Please choose an image to upload.";
            return RedirectToAction(nameof(Index));
        }

        var extension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();

        if (!AllowedExtensions.Contains(extension))
        {
            TempData["Error"] = "Allowed file types: JPG, PNG, WEBP, GIF, SVG, ICO.";
            return RedirectToAction(nameof(Index));
        }

        var safeUsageType = string.IsNullOrWhiteSpace(usageType) ? "Page" : usageType.Trim();
        var uploadsRoot = Path.Combine(environment.WebRootPath, "uploads", "media", safeUsageType.ToLowerInvariant());
        Directory.CreateDirectory(uploadsRoot);

        var fileName = $"{Guid.NewGuid():N}{extension}";
        var fullPath = Path.Combine(uploadsRoot, fileName);

        await using (var stream = System.IO.File.Create(fullPath))
            await imageFile.CopyToAsync(stream);

        var url = $"/uploads/media/{safeUsageType.ToLowerInvariant()}/{fileName}";

        dbContext.MediaAssets.Add(new MediaAsset
        {
            Title = string.IsNullOrWhiteSpace(title)
                ? Path.GetFileNameWithoutExtension(imageFile.FileName)
                : title.Trim(),
            UsageType = safeUsageType,
            AltText = altText?.Trim(),
            Url = url,
            OriginalFileName = imageFile.FileName,
            FileSizeBytes = imageFile.Length,
            UploadedAt = DateTime.UtcNow
        });

        await dbContext.SaveChangesAsync();

        TempData["Success"] = "Image uploaded successfully.";
        return RedirectToAction(nameof(Index), new { usageType = safeUsageType });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var asset = await dbContext.MediaAssets.FindAsync(id);

        if (asset == null)
            return NotFound();

        var relativePath = asset.Url.TrimStart('/').Replace('/', Path.DirectorySeparatorChar);
        var fullPath = Path.Combine(environment.WebRootPath, relativePath);

        if (System.IO.File.Exists(fullPath))
            System.IO.File.Delete(fullPath);

        dbContext.MediaAssets.Remove(asset);
        await dbContext.SaveChangesAsync();

        TempData["Success"] = "Image deleted successfully.";
        return RedirectToAction(nameof(Index));
    }
}
