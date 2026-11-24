// The font choice of the static site: Cursed Souls (default) or the browser's fonts, kept in
// localStorage (no cookie). Loaded in <head> without defer, so the class is set before the page
// paints; the footer button is wired once the document is parsed.
(() => {
    const key = "ss-fonts";
    const browser = "browser";
    const root = document.documentElement;

    const read = () => {
        try {
            return localStorage.getItem(key);
        } catch {
            return null;
        }
    };

    const apply = useBrowser => root.classList.toggle("ss-browser-fonts", useBrowser);

    apply(read() === browser);

    document.addEventListener("DOMContentLoaded", () => {
        const button = document.getElementById("font-toggle");
        if (!button) {
            return;
        }
        const label = () => {
            const useBrowser = root.classList.contains("ss-browser-fonts");
            button.textContent = useBrowser ? "Caratteri Cursed Souls" : "Caratteri del browser";
            button.setAttribute("aria-pressed", String(useBrowser));
        };
        label();
        button.addEventListener("click", () => {
            const useBrowser = !root.classList.contains("ss-browser-fonts");
            apply(useBrowser);
            try {
                if (useBrowser) {
                    localStorage.setItem(key, browser);
                } else {
                    localStorage.removeItem(key);
                }
            } catch {
                // Storage blocked: the choice lasts for this page only.
            }
            label();
        });
    });
})();
