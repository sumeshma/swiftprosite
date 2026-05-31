using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using SwiftPro.Data;
using SwiftPro.Data.Seed;
using SwiftPro.Models.Identity;
using SwiftPro.Services;

var builder = WebApplication.CreateBuilder(args);

// Database
var connectionString =
    Environment.GetEnvironmentVariable("DATABASE_URL")
    ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// MVC
builder.Services.AddControllersWithViews();

// Razor Pages (Required for Identity UI)
builder.Services.AddRazorPages();



// Services
builder.Services.AddScoped<IContactService, ContactService>();

// Identity
builder.Services
    .AddDefaultIdentity<ApplicationUser>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 6;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Identity Login Path
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Admin/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
});

var app = builder.Build();

// Error Handling
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var dbContext =
        services.GetRequiredService<ApplicationDbContext>();

    await dbContext.Database.MigrateAsync();

    await IdentitySeeder.SeedAdminAsync(services);

    await PageSeeder.SeedPagesAsync(dbContext);

    await HeroSectionSeeder.SeedAsync(dbContext);

    await AdminPanelSeeder.SeedAsync(dbContext);
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

// Authentication & Authorization
app.UseAuthentication();

app.UseAuthorization();

// Razor Pages for Identity
app.MapRazorPages();

// Friendly Admin Login Route
app.MapControllerRoute(
    name: "admin-login",
    pattern: "Admin/Login",
    defaults: new { area = "Admin", controller = "Account", action = "Login" });

// Admin Area Route
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

// Default Route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
