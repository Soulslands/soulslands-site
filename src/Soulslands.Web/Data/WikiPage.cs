using System.ComponentModel.DataAnnotations;

namespace Soulslands.Web.Data;

public enum WikiVisibility
{
    Pubblica = 0,
    Staff = 1,
}

public class WikiPage
{
    public int Id { get; set; }

    [MaxLength(100)]
    public required string Slug { get; set; }

    [MaxLength(200)]
    public required string Title { get; set; }

    [MaxLength(100)]
    public string? Category { get; set; }

    public required string Content { get; set; }

    public WikiVisibility Visibility { get; set; }

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // The editor's studio id ("sub"), or "sistema" for pages imported from WikiContent/.
    [MaxLength(256)]
    public string? UpdatedBy { get; set; }

    // The editor's public name when the studio sent one; shown instead of the id.
    [MaxLength(50)]
    public string? UpdatedByName { get; set; }

    public List<WikiRevision> Revisions { get; set; } = [];
}

public class WikiRevision
{
    public int Id { get; set; }

    public int WikiPageId { get; set; }

    public WikiPage? WikiPage { get; set; }

    [MaxLength(200)]
    public required string Title { get; set; }

    public required string Content { get; set; }

    public WikiVisibility Visibility { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Same meaning as WikiPage.UpdatedBy and UpdatedByName.
    [MaxLength(256)]
    public string? Author { get; set; }

    [MaxLength(50)]
    public string? AuthorName { get; set; }
}
