using Soulslands.Web.Data;

namespace Soulslands.Web.Services;

// Groups wiki pages by category. "Classi / Magia" is the subcategory Magia of Classi.
public static class WikiNavigation
{
    private static readonly string[] CategoryOrder =
    [
        "Generale", "Regole di gioco", "Razze", "Classi", "Skill", "Meccaniche",
        "Equipaggiamento", "Risorse", "Mondo", "Creature", "Gilde", "Regole del server", "Sviluppo",
    ];

    public record Section(string Name, List<WikiPage> Pages, List<Section> Children);

    public static List<Section> Build(IEnumerable<WikiPage> pages)
    {
        var roots = new Dictionary<string, Section>();
        foreach (var page in pages)
        {
            var parts = (page.Category ?? "Altro").Split('/', 2, StringSplitOptions.TrimEntries);
            if (!roots.TryGetValue(parts[0], out var root))
            {
                root = new Section(parts[0], [], []);
                roots[parts[0]] = root;
            }

            if (parts.Length == 1)
            {
                root.Pages.Add(page);
                continue;
            }

            var child = root.Children.FirstOrDefault(c => c.Name == parts[1]);
            if (child is null)
            {
                child = new Section(parts[1], [], []);
                root.Children.Add(child);
            }
            child.Pages.Add(page);
        }

        foreach (var root in roots.Values)
        {
            Sort(root);
        }

        return roots.Values
            .OrderBy(r => Array.IndexOf(CategoryOrder, r.Name) is var i && i >= 0 ? i : CategoryOrder.Length)
            .ThenBy(r => r.Name)
            .ToList();
    }

    private static void Sort(Section section)
    {
        // Overview pages (slug equal to the category, e.g. "razze") come first.
        section.Pages.Sort((a, b) =>
        {
            var overview = IsOverview(b).CompareTo(IsOverview(a));
            return overview != 0 ? overview : string.Compare(a.Title, b.Title, StringComparison.CurrentCulture);
        });
        section.Children.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.CurrentCulture));
        foreach (var child in section.Children)
        {
            Sort(child);
        }
    }

    private static bool IsOverview(WikiPage page) => !page.Slug.Contains('-');

    public static int Count(Section section) => section.Pages.Count + section.Children.Sum(Count);
}
