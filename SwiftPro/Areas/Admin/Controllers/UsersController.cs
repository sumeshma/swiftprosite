using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftPro.Areas.Admin.Models;
using SwiftPro.Models.Identity;

namespace SwiftPro.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class UsersController(
    UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager) : Controller
{
    public async Task<IActionResult> Index()
    {
        var users = await userManager.Users
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();

        var model = new List<UserListItemViewModel>();

        foreach (var user in users)
        {
            model.Add(new UserListItemViewModel
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                IsActive = user.IsActive,
                CreatedAt = user.CreatedAt,
                Roles = await userManager.GetRolesAsync(user)
            });
        }

        return View(model);
    }

    public async Task<IActionResult> Create()
    {
        return View(new CreateUserViewModel
        {
            IsActive = true,
            AvailableRoles = await GetRoleNames()
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateUserViewModel model)
    {
        model.AvailableRoles = await GetRoleNames();

        if (!ModelState.IsValid)
            return View(model);

        var user = new ApplicationUser
        {
            FullName = model.FullName.Trim(),
            Email = model.Email.Trim(),
            UserName = model.Email.Trim(),
            EmailConfirmed = true,
            IsActive = model.IsActive,
            CreatedAt = DateTime.UtcNow
        };

        var result = await userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(model);
        }

        if (model.SelectedRoles.Any())
            await userManager.AddToRolesAsync(user, model.SelectedRoles);

        TempData["Success"] = "User created successfully.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> EditRoles(string id)
    {
        var user = await userManager.FindByIdAsync(id);

        if (user == null)
            return NotFound();

        return View(new EditUserRolesViewModel
        {
            UserId = user.Id,
            FullName = user.FullName ?? string.Empty,
            Email = user.Email ?? string.Empty,
            IsActive = user.IsActive,
            SelectedRoles = (await userManager.GetRolesAsync(user)).ToList(),
            AvailableRoles = await GetRoleNames()
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditRoles(EditUserRolesViewModel model)
    {
        model.AvailableRoles = await GetRoleNames();

        var user = await userManager.FindByIdAsync(model.UserId);

        if (user == null)
            return NotFound();

        if (!ModelState.IsValid)
            return View(model);

        user.FullName = model.FullName.Trim();
        user.IsActive = model.IsActive;

        var updateResult = await userManager.UpdateAsync(user);

        if (!updateResult.Succeeded)
        {
            foreach (var error in updateResult.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(model);
        }

        var currentRoles = await userManager.GetRolesAsync(user);
        var rolesToRemove = currentRoles.Except(model.SelectedRoles).ToList();
        var rolesToAdd = model.SelectedRoles.Except(currentRoles).ToList();

        if (rolesToRemove.Any())
            await userManager.RemoveFromRolesAsync(user, rolesToRemove);

        if (rolesToAdd.Any())
            await userManager.AddToRolesAsync(user, rolesToAdd);

        TempData["Success"] = "User permissions updated successfully.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> ChangePassword(string id)
    {
        var user = await userManager.FindByIdAsync(id);

        if (user == null)
            return NotFound();

        return View(new ChangeUserPasswordViewModel
        {
            UserId = user.Id,
            FullName = user.FullName ?? string.Empty,
            Email = user.Email ?? string.Empty
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ChangePassword(ChangeUserPasswordViewModel model)
    {
        var user = await userManager.FindByIdAsync(model.UserId);

        if (user == null)
            return NotFound();

        model.FullName = user.FullName ?? string.Empty;
        model.Email = user.Email ?? string.Empty;

        if (!ModelState.IsValid)
            return View(model);

        var resetToken = await userManager.GeneratePasswordResetTokenAsync(user);
        var result = await userManager.ResetPasswordAsync(user, resetToken, model.NewPassword);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(model);
        }

        user.EmailConfirmed = true;
        user.LockoutEnd = null;
        user.AccessFailedCount = 0;
        await userManager.UpdateAsync(user);
        await userManager.UpdateSecurityStampAsync(user);

        TempData["Success"] = $"Password changed successfully for {model.Email}.";
        return RedirectToAction(nameof(Index));
    }

    private async Task<List<string>> GetRoleNames()
    {
        return await roleManager.Roles
            .OrderBy(x => x.Name)
            .Select(x => x.Name!)
            .ToListAsync();
    }
}
