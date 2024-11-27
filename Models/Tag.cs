using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace snippets.Models;

public class Tag
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public required Guid ProfileId { get; set; }
    
    [ForeignKey("ProfileId")]
    public required Profile Profile { get; set; }
    
    [MaxLength(50)]
    public required string Title { get; set; }

    [MinLength(7), MaxLength(7)]
    public string Color { get; set; } = "#B8B8B8";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}