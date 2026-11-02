// Floating embers drawn on a canvas behind the page.
(() => {
    const canvas = document.getElementById("embers");
    if (!canvas || window.matchMedia("(prefers-reduced-motion: reduce)").matches) {
        return;
    }

    const ctx = canvas.getContext("2d");

    // Colours come from theme.css, so changing the palette there also
    // recolours the particles.
    const theme = getComputedStyle(document.documentElement);
    const hue = (name, fallback) => parseFloat(theme.getPropertyValue(name)) || fallback;
    const palette = {
        emberHue: hue("--ss-ember-hue", 18),
        emberHueRange: hue("--ss-ember-hue-range", 22),
        sparkHue: hue("--ss-spark-hue", 186),
    };
    const embers = [];
    let width = 0;
    let height = 0;

    function resize() {
        const ratio = window.devicePixelRatio || 1;
        width = window.innerWidth;
        height = window.innerHeight;
        canvas.width = width * ratio;
        canvas.height = height * ratio;
        ctx.setTransform(ratio, 0, 0, ratio, 0, 0);
    }

    function spawn(anywhere) {
        return {
            x: Math.random() * width,
            y: anywhere ? Math.random() * height : height + 10,
            radius: 0.6 + Math.random() * 2.2,
            speed: 0.2 + Math.random() * 0.7,
            drift: (Math.random() - 0.5) * 0.4,
            phase: Math.random() * Math.PI * 2,
            // A rare cyan spark among the orange embers.
            hue: Math.random() < 0.04 ? palette.sparkHue : palette.emberHue + Math.random() * palette.emberHueRange,
            life: 0.4 + Math.random() * 0.6,
        };
    }

    function frame(time) {
        ctx.clearRect(0, 0, width, height);
        ctx.globalCompositeOperation = "lighter";

        for (let i = 0; i < embers.length; i++) {
            const e = embers[i];
            e.y -= e.speed;
            e.x += e.drift + Math.sin(time / 1200 + e.phase) * 0.3;

            if (e.y < -10 || e.x < -10 || e.x > width + 10) {
                embers[i] = spawn(false);
                continue;
            }

            // Embers fade out as they rise.
            const alpha = Math.max(0, Math.min(1, e.y / height)) * e.life;
            const glow = e.radius * 4;
            const gradient = ctx.createRadialGradient(e.x, e.y, 0, e.x, e.y, glow);
            gradient.addColorStop(0, `hsla(${e.hue}, 100%, 65%, ${alpha})`);
            gradient.addColorStop(0.4, `hsla(${e.hue}, 100%, 50%, ${alpha * 0.35})`);
            gradient.addColorStop(1, `hsla(${e.hue}, 100%, 40%, 0)`);
            ctx.fillStyle = gradient;
            ctx.beginPath();
            ctx.arc(e.x, e.y, glow, 0, Math.PI * 2);
            ctx.fill();
        }

        requestAnimationFrame(frame);
    }

    resize();
    window.addEventListener("resize", resize);

    const count = Math.round(Math.min(90, (width * height) / 18000));
    for (let i = 0; i < count; i++) {
        embers.push(spawn(true));
    }

    requestAnimationFrame(frame);
})();
