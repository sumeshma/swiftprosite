using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftPro.Areas.Admin.Models;
using SwiftPro.Models.Identity;

namespace SwiftPro.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class RolesController(
    RoleManager<IdentityRole> roleManager,
    UserManager<ApplicationUser> userManager) : Controller
{
    public async Task<IActionResult> Index()
    {
        var roles = await roleManager.Roles
            .OrderBy(x => x.Name)
            .ToListAsync();

        return View(roles);
    }

    public IActionResult Create()
    {
        return View(new CreateRoleViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateRoleViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var roleName = model.Name.Trim();

        if (await roleManager.RoleExistsAsync(roleName))
        {
            ModelState.AddModelError(nameof(model.Name), "This role already exists.");
            return View(model);
        }

        var result = await roleManager.CreateAsync(new IdentityRole(roleName));

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(model);
        }

        TempData["Success"] = "Role created successfully.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(string id)
    {
        var role = await roleManager.FindByIdAsync(id);

        if (role == null)
            return NotFound();

        var usersInRole = await userManager.GetUsersInRoleAsync(role.Name!);

        if (usersInRole.Any())
        {
            TempData["Error"] = "This role is assigned to users and cannot be deleted.";
            return RedirectToAction(nameof(Index));
        }

        await roleManager.DeleteAsync(role);

        TempData["Success"] = "Role deleted successfully.";
        return RedirectToAction(nameof(Index));
    }
}
