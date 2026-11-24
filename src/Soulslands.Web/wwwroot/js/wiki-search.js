// Wiki search of the static site: filters the index written by the export (slug, title, category,
// plain-text cut of every public page) in the browser. Results are built with textContent only.
(() => {
    const box = document.getElementById("wiki-search");
    const input = document.getElementById("wiki-search-input");
    const results = document.getElementById("wiki-search-results");
    const empty = document.getElementById("wiki-search-empty");
    const tree = document.getElementById("wiki-index");
    if (!box || !input || !results || !empty || !box.dataset.index) {
        return;
    }
    const maxResults = 50;
    let pages = null;
    let loading = null;

    // Lower case without accents, so "citta" finds "Città".
    const fold = text => (text || "").normalize("NFD").replace(/[̀-ͯ]/g, "").toLowerCase();

    const load = () => {
        loading ??= fetch(box.dataset.index)
            .then(response => (response.ok ? response.json() : []))
            .then(list => {
                pages = (Array.isArray(list) ? list : []).map(p => ({
                    ...p,
                    keyTitle: fold(p.title),
                    keyRest: fold(`${p.category || ""} ${p.text || ""}`),
                }));
            })
            .catch(() => {
                pages = [];
            });
        return loading;
    };

    const render = () => {
        const words = fold(input.value).split(/\s+/).filter(Boolean);
        results.replaceChildren();
        if (words.length === 0 || pages === null) {
            empty.hidden = true;
            tree.hidden = false;
            return;
        }
        const scored = [];
        for (const page of pages) {
            if (!words.every(w => page.keyTitle.includes(w) || page.keyRest.includes(w))) {
                continue;
            }
            const score = words.filter(w => page.keyTitle.includes(w)).length;
            scored.push({ page, score });
        }
        scored.sort((a, b) => b.score - a.score || a.page.title.localeCompare(b.page.title, "it"));
        for (const { page } of scored.slice(0, maxResults)) {
            const li = document.createElement("li");
            li.className = "py-1";
            const link = document.createElement("a");
            link.href = `/wiki/${encodeURIComponent(page.slug)}`;
            link.textContent = page.title;
            li.append(link);
            if (page.category) {
                const category = document.createElement("small");
                category.className = "text-muted-ss ms-2";
                category.textContent = page.category;
                li.append(category);
            }
            results.append(li);
        }
        empty.hidden = scored.length > 0;
        tree.hidden = true;
    };

    box.hidden = false;
    input.addEventListener("focus", load, { once: true });
    input.addEventListener("input", () => load().then(render));
    if (input.value) {
        load().then(render);
    }
})();
