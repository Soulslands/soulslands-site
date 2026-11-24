namespace Soulslands.Web.Services;

// One page of the public wiki, read from its Markdown file in WikiContent/ (WikiStore).
// UpdatedAt is the committer date of the file's last Git commit, or default when Git cannot tell
// (no repository, a shallow clone): pages then show no "Aggiornata il" line.
public sealed record WikiPage(string Slug, string Title, string? Category, string Content, DateTime UpdatedAt = default);
