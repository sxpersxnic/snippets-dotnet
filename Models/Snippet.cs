using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace snippets.Models;

public class Snippet
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public required Guid ProfileId { get; set; }
    
    [ForeignKey("ProfileId")]
    public required Profile Profile { get; set; }
    
    [MaxLength(100)]
    public required string Name { get; set; }
    
    [MaxLength(100)]
    public required string Language { get; set; }
    
    public required string Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}