using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SwiftPro.Areas.Admin.Models;
using SwiftPro.Models.Identity;

namespace SwiftPro.Areas.Admin.Controllers;

[Area("Admin")]
public class AccountController(
    SignInManager<ApplicationUser> signInManager,
    UserManager<ApplicationUser> userManager) : Controller
{
    [AllowAnonymous]
    public IActionResult Login(string? returnUrl = null)
    {
        if (User.Identity?.IsAuthenticated == true)
            return RedirectToLocal(returnUrl);

        return View(new AdminLoginViewModel
        {
            ReturnUrl = returnUrl
        });
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(AdminLoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = await userManager.FindByEmailAsync(model.Email.Trim());

        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Invalid email or password.");
            return View(model);
        }

        if (!user.IsActive)
        {
            ModelState.AddModelError(string.Empty, "This user account is disabled.");
            return View(model);
        }

        if (!user.EmailConfirmed)
        {
            user.EmailConfirmed = true;
            await userManager.UpdateAsync(user);
        }

        var result = await signInManager.PasswordSignInAsync(
            user,
            model.Password,
            model.RememberMe,
            lockoutOnFailure: false);

        if (result.Succeeded)
            return RedirectToLocal(model.ReturnUrl);

        if (result.IsLockedOut)
            ModelState.AddModelError(string.Empty, "This account is locked. Change the password from Users to unlock it.");
        else
            ModelState.AddModelError(string.Empty, "Invalid email or password.");

        return View(model);
    }

    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction(nameof(Login));
    }

    private IActionResult RedirectToLocal(string? returnUrl)
    {
        if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
            return Redirect(returnUrl);

        return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
    }
}
