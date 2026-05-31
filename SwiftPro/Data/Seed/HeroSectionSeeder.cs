using SwiftPro.Models;

namespace SwiftPro.Data.Seed;

public static class HeroSectionSeeder
{
    public static async Task SeedAsync(ApplicationDbContext dbContext)
    {
        if (dbContext.HeroSections.Any())
            return;

        var hero = new HeroSection
        {
            BadgeText = "Engineering Future-Ready Software",

            Title = "Building premium digital products for ambitious companies.",

            Subtitle = "SwiftPro Solutions helps startups and enterprises design, build, and scale resilient web, cloud, and SaaS platforms.",

            PrimaryButtonText = "Book a Discovery Call",
            PrimaryButtonUrl = "/Contact",

            SecondaryButtonText = "View Portfolio",
            SecondaryButtonUrl = "/Company/Portfolio"
        };

        dbContext.HeroSections.Add(hero);

        await dbContext.SaveChangesAsync();
    }
}