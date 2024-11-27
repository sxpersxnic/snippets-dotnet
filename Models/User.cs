using System.ComponentModel.DataAnnotations;

namespace snippets.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [MaxLength(100)]
    public required string Email { get; set; }

    [MaxLength(255), MinLength(8)] 
    public required string Password { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}