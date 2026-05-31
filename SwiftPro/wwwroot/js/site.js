(() => {
    const navbar = document.getElementById("mainNavbar");
    if (navbar) {
        const applyNavbarState = () => {
            if (window.scrollY > 20) {
                navbar.classList.add("navbar-scrolled");
            } else {
                navbar.classList.remove("navbar-scrolled");
            }
        };

        applyNavbarState();
        window.addEventListener("scroll", applyNavbarState, { passive: true });
    }

    const revealItems = document.querySelectorAll(".reveal-up");
    if (revealItems.length > 0) {
        const observer = new IntersectionObserver((entries) => {
            entries.forEach((entry) => {
                if (entry.isIntersecting) {
                    entry.target.classList.add("in-view");
                    observer.unobserve(entry.target);
                }
            });
        }, { threshold: 0.15 });

        revealItems.forEach((item) => observer.observe(item));
    }
})();
