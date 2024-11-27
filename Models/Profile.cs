using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace snippets.Models;

public class Profile
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public required Guid UserId { get; set; }
    
    [ForeignKey("UserId")]
    public required User User { get; set; }
    
    [MaxLength(50)]
    public required string Username { get; set; }
    
    [MaxLength(255)]
    public string Photo { get; set; } = "/pfp/default-32x32.png";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}