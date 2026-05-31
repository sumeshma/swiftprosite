(() => {
    const counterElements = document.querySelectorAll(".counter-value");
    if (counterElements.length === 0) {
        return;
    }

    const runCounter = (element) => {
        const target = Number(element.getAttribute("data-target"));
        const duration = 1800;
        const startAt = performance.now();

        const step = (timestamp) => {
            const progress = Math.min((timestamp - startAt) / duration, 1);
            const current = Math.floor(progress * target);
            element.textContent = current.toString();
            if (progress < 1) {
                requestAnimationFrame(step);
            } else {
                element.textContent = target.toString();
            }
        };

        requestAnimationFrame(step);
    };

    const observer = new IntersectionObserver((entries) => {
        entries.forEach((entry) => {
            if (!entry.isIntersecting) {
                return;
            }

            runCounter(entry.target);
            observer.unobserve(entry.target);
        });
    }, { threshold: 0.4 });

    counterElements.forEach((element) => observer.observe(element));
})();
