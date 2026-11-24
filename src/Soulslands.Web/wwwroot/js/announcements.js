// The "Bacheca" of the static home page: the studio's announcements for Soulslands, fetched in the
// browser. Their text is plain text written by studio admins and is inserted only as text
// (textContent), never as HTML. The section stays hidden when the list is empty or the fetch fails.
(() => {
    const section = document.getElementById("bacheca");
    const source = section?.dataset.src;
    if (!section || !source) {
        return;
    }
    const list = section.querySelector("ul");
    const shown = 5;

    const day = value => {
        const date = new Date(value);
        if (Number.isNaN(date.getTime())) {
            return "";
        }
        const two = n => String(n).padStart(2, "0");
        return `${two(date.getUTCDate())}/${two(date.getUTCMonth() + 1)}`;
    };

    fetch(source, { credentials: "omit", headers: { Accept: "application/json" } })
        .then(response => (response.ok ? response.json() : []))
        .then(items => {
            if (!Array.isArray(items)) {
                return;
            }
            const valid = items.filter(item => item && typeof item.text === "string" && item.text.trim() !== "").slice(0, shown);
            for (const item of valid) {
                const li = document.createElement("li");
                li.className = "py-1";
                const when = document.createElement("span");
                when.className = "text-cyan small me-2";
                when.textContent = day(item.createdAt);
                li.append(when, document.createTextNode(item.text));
                list.append(li);
            }
            section.hidden = valid.length === 0;
        })
        .catch(() => {
            section.hidden = true;
        });
})();
