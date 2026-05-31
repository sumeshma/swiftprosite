//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.EntityFrameworkCore;
//using SwiftPro.Models;

//namespace SwiftPro.Data;

//public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
//{
//    public DbSet<ContactMessage> ContactMessages => Set<ContactMessage>();
//    public DbSet<CmsPage> Pages => Set<CmsPage>();

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        base.OnModelCreating(modelBuilder);

//        modelBuilder.Entity<ContactMessage>(entity =>
//        {
//            entity.HasKey(e => e.Id);
//            entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
//            entity.Property(e => e.Email).HasMaxLength(150).IsRequired();
//            entity.Property(e => e.Subject).HasMaxLength(150).IsRequired();
//            entity.Property(e => e.Message).HasMaxLength(2500).IsRequired();
//            entity.Property(e => e.CreatedUtc).IsRequired();
//        });
//    }
//}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SwiftPro.Models;
using SwiftPro.Models.Identity;

namespace SwiftPro.Data;

public class ApplicationDbContext
    : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ContactMessage> ContactMessages => Set<ContactMessage>();

    public DbSet<CmsPage> Pages => Set<CmsPage>();

    public DbSet<HomeSection> HomeSections => Set<HomeSection>();

    public DbSet<HeroSection> HeroSections => Set<HeroSection>();

    public DbSet<NavigationMenuItem> NavigationMenuItems => Set<NavigationMenuItem>();

    public DbSet<SiteSetting> SiteSettings => Set<SiteSetting>();

    public DbSet<MediaAsset> MediaAssets => Set<MediaAsset>();
}
