using System.ComponentModel.DataAnnotations;

namespace Soulslands.Web.Data;

// A short notice shown on the home page board.
public class Announcement
{
    public int Id { get; set; }

    [MaxLength(300)]
    public required string Text { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
