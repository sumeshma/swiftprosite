using SwiftPro.Models;

namespace SwiftPro.Data.Seed;

public static class PageSeeder
{
    public static async Task SeedPagesAsync(ApplicationDbContext dbContext)
    {
        var pages = new List<CmsPage>
        {
            new()
            {
                Title = "Home",
                Slug = "home",
                Content = """
<section class="py-5 bg-white">
    <div class="container py-4">
        <div class="text-center mb-5 reveal-up">
            <h2 class="section-title">Services crafted for growth</h2>
            <p class="section-subtitle mx-auto">From idea validation to product scaling, our teams align technology with business goals for measurable impact.</p>
        </div>
        <div class="row g-4">
            <div class="col-md-6 col-xl-3 reveal-up"><article class="service-card h-100 p-4"><i class="bi bi-code-square fs-2 text-primary"></i><h5 class="mt-3">Custom Software</h5><p class="mb-0 text-secondary">Tailored web and enterprise software engineered around your workflows.</p></article></div>
            <div class="col-md-6 col-xl-3 reveal-up"><article class="service-card h-100 p-4"><i class="bi bi-cloud-arrow-up fs-2 text-primary"></i><h5 class="mt-3">Cloud Solutions</h5><p class="mb-0 text-secondary">Scalable cloud architecture, migration, and optimization for reliability.</p></article></div>
            <div class="col-md-6 col-xl-3 reveal-up"><article class="service-card h-100 p-4"><i class="bi bi-graph-up-arrow fs-2 text-primary"></i><h5 class="mt-3">Product Engineering</h5><p class="mb-0 text-secondary">Rapid SaaS product development with robust quality and release practices.</p></article></div>
            <div class="col-md-6 col-xl-3 reveal-up"><article class="service-card h-100 p-4"><i class="bi bi-shield-check fs-2 text-primary"></i><h5 class="mt-3">Support & Evolution</h5><p class="mb-0 text-secondary">Continuous support, optimization, and feature evolution for long-term value.</p></article></div>
        </div>
    </div>
</section>
""",
                MetaTitle = "SwiftPro Solutions",
                MetaDescription = "SwiftPro Solutions is a modern software company delivering scalable digital products and enterprise solutions."
            },
            new()
            {
                Title = "About",
                Slug = "about",
                Content = """
<section class="py-5 bg-white">
    <div class="container py-5">
        <h1 class="section-title mb-3">About SwiftPro Solutions</h1>
        <p class="lead text-secondary">We are a software engineering company focused on building high-impact digital products and scalable enterprise systems.</p>
        <div class="row g-4 mt-4">
            <div class="col-lg-6"><h5>Our Mission</h5><p class="text-secondary">To empower organizations with resilient software, modern architecture, and continuous innovation.</p></div>
            <div class="col-lg-6"><h5>Our Values</h5><p class="text-secondary">Ownership, craftsmanship, transparency, and long-term partnership define how we deliver value.</p></div>
        </div>
    </div>
</section>
""",
                MetaTitle = "About Us",
                MetaDescription = "Learn about SwiftPro Solutions, our mission, values, and software delivery approach."
            },
            new()
            {
                Title = "Services",
                Slug = "services",
                Content = """
<section class="py-5">
    <div class="container py-5">
        <h1 class="section-title mb-3">Services</h1>
        <p class="lead text-secondary">End-to-end services to design, build, modernize, and scale your digital products.</p>
        <div class="row g-4 mt-3">
            <div class="col-md-6 col-lg-4"><div class="service-card p-4 h-100"><h5>Custom Product Development</h5><p class="text-secondary mb-0">Design and engineering for web and SaaS products.</p></div></div>
            <div class="col-md-6 col-lg-4"><div class="service-card p-4 h-100"><h5>Legacy Modernization</h5><p class="text-secondary mb-0">Refactor and migrate systems to modern stacks.</p></div></div>
            <div class="col-md-6 col-lg-4"><div class="service-card p-4 h-100"><h5>Cloud & DevOps</h5><p class="text-secondary mb-0">Cloud adoption, CI/CD, and reliability engineering.</p></div></div>
        </div>
    </div>
</section>
""",
                MetaTitle = "Services",
                MetaDescription = "Explore SwiftPro Solutions software services including custom product development, modernization, and support."
            },
            new()
            {
                Title = "Technologies",
                Slug = "technologies",
                Content = """
<section class="py-5 bg-white">
    <div class="container py-5">
        <h1 class="section-title mb-3">Technologies</h1>
        <p class="lead text-secondary">Our engineering teams build on proven, modern technologies for performance and scale.</p>
        <div class="d-flex flex-wrap gap-3 mt-4">
            <span class="tech-pill">C# / .NET</span><span class="tech-pill">ASP.NET Core MVC</span><span class="tech-pill">Entity Framework Core</span><span class="tech-pill">PostgreSQL</span><span class="tech-pill">Azure / AWS</span><span class="tech-pill">Docker / Kubernetes</span><span class="tech-pill">Bootstrap 5</span><span class="tech-pill">Vanilla JavaScript</span>
        </div>
    </div>
</section>
""",
                MetaTitle = "Technologies",
                MetaDescription = "Discover technologies and platforms used by SwiftPro Solutions for modern product engineering."
            },
            new()
            {
                Title = "Portfolio",
                Slug = "portfolio",
                Content = """
<section class="portfolio-hero py-5">
    <div class="container py-5"><div class="row align-items-center g-4"><div class="col-lg-7"><span class="badge rounded-pill portfolio-badge px-3 py-2 mb-3">Our Work</span><h1 class="display-5 fw-bold text-white mb-3">Portfolio that drives measurable business impact</h1><p class="lead text-white-50 mb-0">From product launches to modernization programs, SwiftPro helps organizations build scalable, user-focused software systems.</p></div><div class="col-lg-5"><div class="portfolio-stat-card p-4"><div class="row g-3 text-center"><div class="col-6"><h3 class="mb-1">150+</h3><small>Projects Delivered</small></div><div class="col-6"><h3 class="mb-1">90+</h3><small>Global Clients</small></div><div class="col-6"><h3 class="mb-1">98%</h3><small>Retention Rate</small></div><div class="col-6"><h3 class="mb-1">12+</h3><small>Years Experience</small></div></div></div></div></div></div>
</section>
<section class="py-5 bg-white">
    <div class="container"><div class="portfolio-featured p-4 p-lg-5"><div class="row align-items-center g-4"><div class="col-lg-8"><p class="text-uppercase small fw-semibold text-primary mb-2">Featured Product</p><h2 class="mb-3">Corefit - Gym Management Software</h2><p class="text-secondary mb-4">Corefit centralizes member management, plan renewals, billing, attendance, trainer workflows, and operational analytics in a single platform for modern fitness businesses.</p><div class="d-flex flex-wrap gap-2 mb-4"><span class="portfolio-pill">Memberships</span><span class="portfolio-pill">Billing</span><span class="portfolio-pill">Attendance</span><span class="portfolio-pill">Trainer Plans</span><span class="portfolio-pill">Analytics</span></div><a class="btn btn-primary rounded-pill px-4" href="/Company/Corefit">Explore Corefit Case Study</a></div><div class="col-lg-4"><div class="portfolio-mini-preview p-3"><img src="/images/corefit/dashboard-desktop.png" alt="Corefit dashboard preview" class="img-fluid rounded-3" /></div></div></div></div></div>
</section>
<section class="py-5">
    <div class="container"><div class="d-flex justify-content-between align-items-end flex-wrap gap-2 mb-4"><h2 class="section-title mb-0">More success stories</h2><p class="text-secondary mb-0">Selected delivery examples across domains</p></div><div class="row g-4"><div class="col-md-6 col-xl-4"><article class="portfolio-card h-100 p-4"><div class="portfolio-icon"><i class="bi bi-heart-pulse"></i></div><h5>HealthTech Portal</h5><p class="text-secondary mb-0">Delivered patient onboarding, appointment workflows, and analytics on a cloud-native platform.</p></article></div><div class="col-md-6 col-xl-4"><article class="portfolio-card h-100 p-4"><div class="portfolio-icon"><i class="bi bi-building-gear"></i></div><h5>B2B SaaS Suite</h5><p class="text-secondary mb-0">Modernized monolithic architecture to microservices and improved release velocity and uptime.</p></article></div><div class="col-md-6 col-xl-4"><article class="portfolio-card h-100 p-4"><div class="portfolio-icon"><i class="bi bi-currency-exchange"></i></div><h5>FinTech Platform</h5><p class="text-secondary mb-0">Implemented secure transaction workflows and reporting automation for a high-growth startup.</p></article></div></div></div>
</section>
""",
                MetaTitle = "Portfolio",
                MetaDescription = "See selected SwiftPro Solutions projects and delivery outcomes across industries."
            },
            new()
            {
                Title = "Corefit",
                Slug = "corefit",
                Content = """
<section class="corefit-hero position-relative overflow-hidden">
    <div class="container py-5 py-lg-6"><div class="row align-items-center g-5"><div class="col-lg-6"><span class="badge rounded-pill corefit-badge px-3 py-2 mb-3">Portfolio Product</span><h1 class="display-5 fw-bold text-white mb-3">Corefit - Gym Management Software</h1><p class="text-light-emphasis fs-5 mb-4">A modern all-in-one gym operating system built by SwiftPro Solutions for memberships, billing, trainer coordination, attendance, and business analytics.</p><div class="d-flex flex-wrap gap-2 mb-4"><span class="corefit-tag"><i class="bi bi-people-fill"></i> Members</span><span class="corefit-tag"><i class="bi bi-credit-card-2-front-fill"></i> Billing</span><span class="corefit-tag"><i class="bi bi-calendar-check-fill"></i> Attendance</span><span class="corefit-tag"><i class="bi bi-graph-up-arrow"></i> Insights</span></div><div class="d-flex flex-wrap gap-3"><a class="btn btn-primary rounded-pill px-4" href="/Contact">Request a Demo</a><a class="btn btn-outline-light rounded-pill px-4" href="#corefit-showcase">View Screens</a></div></div><div class="col-lg-6"><div class="corefit-snapshot-card"><img src="/images/corefit/dashboard-desktop.png" alt="Corefit desktop dashboard preview" class="img-fluid rounded-4 shadow-lg" /></div></div></div></div>
</section>
<section id="corefit-showcase" class="py-5 bg-white">
    <div class="container"><div class="text-center mb-5"><h2 class="section-title">Real product, real workflow</h2><p class="section-subtitle mx-auto">Desktop and mobile experiences are crafted for speed, clarity, and day-to-day gym operations.</p></div><div class="row align-items-center g-5"><div class="col-lg-8"><div class="corefit-device-frame desktop-frame p-3 p-lg-4"><img src="/images/corefit/dashboard-desktop.png" alt="Corefit desktop view with dashboard metrics and modules" class="img-fluid rounded-3" /></div></div><div class="col-lg-4"><div class="corefit-device-frame mobile-frame p-2 mx-auto"><img src="/images/corefit/dashboard-mobile.png" alt="Corefit mobile view for quick dashboard tracking" class="img-fluid rounded-4" /></div></div></div></div>
</section>
<section class="py-5">
    <div class="container"><div class="row g-4 mb-4"><div class="col-lg-6"><div class="choose-card p-4 h-100"><h5 class="d-flex align-items-center gap-2"><i class="bi bi-puzzle-fill text-primary"></i>What Corefit solves</h5><p class="text-secondary mb-0">Most fitness centers rely on separate tools for admissions, plans, attendance, and trainer scheduling. Corefit unifies operations in one connected platform for owners, managers, and coaches.</p></div></div><div class="col-lg-6"><div class="choose-card p-4 h-100"><h5 class="d-flex align-items-center gap-2"><i class="bi bi-trophy-fill text-primary"></i>Business impact</h5><p class="text-secondary mb-0">Teams reduce manual effort, avoid renewal misses, improve member retention, and make faster decisions using clear, centralized metrics.</p></div></div></div><h2 class="section-title mb-4">Key features</h2><div class="row g-4"><div class="col-md-6 col-lg-4"><div class="service-card corefit-feature p-4 h-100"><div class="corefit-feature-icon"><i class="bi bi-people-fill"></i></div><h5>Member Management</h5><p class="text-secondary mb-0">Manage profiles, subscriptions, and membership history with role-based access.</p></div></div><div class="col-md-6 col-lg-4"><div class="service-card corefit-feature p-4 h-100"><div class="corefit-feature-icon"><i class="bi bi-wallet2"></i></div><h5>Plans & Billing</h5><p class="text-secondary mb-0">Create flexible plans, track renewals, and monitor payments and dues in real time.</p></div></div><div class="col-md-6 col-lg-4"><div class="service-card corefit-feature p-4 h-100"><div class="corefit-feature-icon"><i class="bi bi-clipboard2-check-fill"></i></div><h5>Attendance Tracking</h5><p class="text-secondary mb-0">Log daily attendance and generate insights on member activity and peak hours.</p></div></div><div class="col-md-6 col-lg-4"><div class="service-card corefit-feature p-4 h-100"><div class="corefit-feature-icon"><i class="bi bi-person-workspace"></i></div><h5>Trainer Scheduling</h5><p class="text-secondary mb-0">Allocate trainers, sessions, and workout programs efficiently.</p></div></div><div class="col-md-6 col-lg-4"><div class="service-card corefit-feature p-4 h-100"><div class="corefit-feature-icon"><i class="bi bi-bar-chart-line-fill"></i></div><h5>Reports & Analytics</h5><p class="text-secondary mb-0">Track revenue, retention, and performance with actionable dashboards.</p></div></div><div class="col-md-6 col-lg-4"><div class="service-card corefit-feature p-4 h-100"><div class="corefit-feature-icon"><i class="bi bi-bell-fill"></i></div><h5>Notifications</h5><p class="text-secondary mb-0">Automated reminders for renewals, dues, and important member updates.</p></div></div></div><div class="text-center mt-5"><a class="btn btn-primary rounded-pill px-4" href="/Contact">Request a Demo</a></div></div>
</section>
""",
                MetaTitle = "Corefit | Gym Management Software",
                MetaDescription = "Corefit is a gym management software platform built by SwiftPro Solutions for membership, billing, attendance, and analytics."
            },
            new()
            {
                Title = "Xersio",
                Slug = "xersio",
                Content = """
<section class="xersio-hero position-relative overflow-hidden">
    <div class="container py-5 py-lg-6"><div class="row align-items-center g-5"><div class="col-lg-6"><span class="badge rounded-pill xersio-badge px-3 py-2 mb-3">Portfolio Product</span><h1 class="display-5 fw-bold text-white mb-3">Xersio - Gym Management Software</h1><p class="text-light-emphasis fs-5 mb-4">A modern all-in-one gym operating system built by SwiftPro Solutions for memberships, billing, trainer coordination, attendance, and business analytics.</p><div class="d-flex flex-wrap gap-2 mb-4"><span class="xersio-tag"><i class="bi bi-people-fill"></i> Members</span><span class="xersio-tag"><i class="bi bi-credit-card-2-front-fill"></i> Billing</span><span class="xersio-tag"><i class="bi bi-calendar-check-fill"></i> Attendance</span><span class="xersio-tag"><i class="bi bi-graph-up-arrow"></i> Insights</span></div><div class="d-flex flex-wrap gap-3"><a class="btn btn-primary rounded-pill px-4" href="/Contact">Request a Demo</a><a class="btn btn-outline-light rounded-pill px-4" href="#xersio-showcase">View Screens</a></div></div><div class="col-lg-6"><div class="xersio-snapshot-card"><img src="/images/xersio/dashboard.png" alt="Xersio dashboard preview" class="img-fluid rounded-4 shadow-lg" /></div></div></div></div>
</section>
<section id="xersio-showcase" class="py-5 bg-white">
    <div class="container"><div class="text-center mb-5"><h2 class="section-title">Real product, real workflow</h2><p class="section-subtitle mx-auto">Desktop and mobile experiences are crafted for speed, clarity, and day-to-day gym operations.</p></div><div class="row align-items-center g-5"><div class="col-lg-8"><div class="xersio-device-frame desktop-frame p-3 p-lg-4"><img src="/images/xersio/dashboard.png" alt="Xersio desktop view with dashboard metrics and modules" class="img-fluid rounded-3" /></div></div><div class="col-lg-4"><div class="xersio-device-frame mobile-frame p-2 mx-auto"><img src="/images/xersio/dashboard.png" alt="Xersio dashboard mobile responsive preview" class="img-fluid rounded-4" /></div></div></div></div>
</section>
<section class="py-5">
    <div class="container"><div class="row g-4 mb-4"><div class="col-lg-6"><div class="choose-card p-4 h-100"><h5 class="d-flex align-items-center gap-2"><i class="bi bi-puzzle-fill text-primary"></i>What Xersio solves</h5><p class="text-secondary mb-0">Most fitness centers rely on separate tools for admissions, plans, attendance, and trainer scheduling. Xersio unifies operations in one connected platform for owners, managers, and coaches.</p></div></div><div class="col-lg-6"><div class="choose-card p-4 h-100"><h5 class="d-flex align-items-center gap-2"><i class="bi bi-trophy-fill text-primary"></i>Business impact</h5><p class="text-secondary mb-0">Teams reduce manual effort, avoid renewal misses, improve member retention, and make faster decisions using clear, centralized metrics.</p></div></div></div><h2 class="section-title mb-4">Key features</h2><div class="row g-4"><div class="col-md-6 col-lg-4"><div class="service-card xersio-feature p-4 h-100"><div class="xersio-feature-icon"><i class="bi bi-people-fill"></i></div><h5>Member Management</h5><p class="text-secondary mb-0">Manage profiles, subscriptions, and membership history with role-based access.</p></div></div><div class="col-md-6 col-lg-4"><div class="service-card xersio-feature p-4 h-100"><div class="xersio-feature-icon"><i class="bi bi-wallet2"></i></div><h5>Plans & Billing</h5><p class="text-secondary mb-0">Create flexible plans, track renewals, and monitor payments and dues in real time.</p></div></div><div class="col-md-6 col-lg-4"><div class="service-card xersio-feature p-4 h-100"><div class="xersio-feature-icon"><i class="bi bi-clipboard2-check-fill"></i></div><h5>Attendance Tracking</h5><p class="text-secondary mb-0">Log daily attendance and generate insights on member activity and peak hours.</p></div></div><div class="col-md-6 col-lg-4"><div class="service-card xersio-feature p-4 h-100"><div class="xersio-feature-icon"><i class="bi bi-person-workspace"></i></div><h5>Trainer Scheduling</h5><p class="text-secondary mb-0">Allocate trainers, sessions, and workout programs efficiently.</p></div></div><div class="col-md-6 col-lg-4"><div class="service-card xersio-feature p-4 h-100"><div class="xersio-feature-icon"><i class="bi bi-bar-chart-line-fill"></i></div><h5>Reports & Analytics</h5><p class="text-secondary mb-0">Track revenue, retention, and performance with actionable dashboards.</p></div></div><div class="col-md-6 col-lg-4"><div class="service-card xersio-feature p-4 h-100"><div class="xersio-feature-icon"><i class="bi bi-bell-fill"></i></div><h5>Notifications</h5><p class="text-secondary mb-0">Automated reminders for renewals, dues, and important member updates.</p></div></div></div><div class="text-center mt-5"><a class="btn btn-primary rounded-pill px-4" href="/Contact">Request a Demo</a></div></div>
</section>
""",
                MetaTitle = "Xersio | Gym Management Software",
                MetaDescription = "Xersio is a gym management software platform built by SwiftPro Solutions for membership, billing, attendance, and analytics."
            },
            new()
            {
                Title = "Careers",
                Slug = "careers",
                Content = """
<section class="py-5 bg-white">
    <div class="container py-5">
        <h1 class="section-title mb-3">Careers at SwiftPro</h1>
        <p class="lead text-secondary">Join a team that values quality engineering, ownership, and continuous learning.</p>
        <div class="row g-4 mt-3">
            <div class="col-md-6"><div class="choose-card p-4 h-100"><h5>Work on meaningful products</h5><p class="text-secondary mb-0">Collaborate with global clients to solve real business and technical challenges.</p></div></div>
            <div class="col-md-6"><div class="choose-card p-4 h-100"><h5>Grow with modern engineering practices</h5><p class="text-secondary mb-0">Mentorship, code quality focus, and continuous upskilling are core to our culture.</p></div></div>
        </div>
        <a class="btn btn-primary rounded-pill px-4 mt-4" href="/Contact">Apply Now</a>
    </div>
</section>
""",
                MetaTitle = "Careers",
                MetaDescription = "Join SwiftPro Solutions and build high-impact products with a modern engineering team."
            },
            new()
            {
                Title = "Contact",
                Slug = "contact",
                Content = """
<h1 class="section-title mb-2">Contact Us</h1>
<p class="text-secondary mb-4">Tell us about your idea, challenge, or project goals. We will respond quickly.</p>
""",
                MetaTitle = "Contact Us",
                MetaDescription = "Get in touch with SwiftPro Solutions for software consulting, product development, and technical partnership."
            }
        };

        foreach (var page in pages)
        {
            var existingPage = dbContext.Pages.FirstOrDefault(x => x.Slug == page.Slug);

            if (existingPage == null)
            {
                dbContext.Pages.Add(page);
                continue;
            }

            if (page.Slug == "xersio")
            {
                existingPage.Content = page.Content;
                existingPage.MetaTitle = page.MetaTitle;
                existingPage.MetaDescription = page.MetaDescription;
                existingPage.UpdatedAt = DateTime.UtcNow;
                continue;
            }

            if (!IsPlaceholderContent(existingPage.Content))
                continue;

            existingPage.Content = page.Content;
            existingPage.MetaTitle = page.MetaTitle;
            existingPage.MetaDescription = page.MetaDescription;
            existingPage.UpdatedAt = DateTime.UtcNow;
        }

        await dbContext.SaveChangesAsync();
    }

    private static bool IsPlaceholderContent(string content)
    {
        var placeholders = new[]
        {
            "<h1>Welcome to SwiftPro</h1>",
            "<h1>About Us</h1>",
            "<h1>Our Services</h1>",
            "<h1>Contact Us</h1>"
        };

        return string.IsNullOrWhiteSpace(content)
            || placeholders.Contains(content.Trim(), StringComparer.OrdinalIgnoreCase);
    }
}
