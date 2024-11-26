using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace snippets.Models
{
    public class Snippet
    {
        [Key] public Guid Id { get; set; } = Guid.NewGuid(); 
        
        [Required]
        public Guid UserId { get; set; }
        
        [ForeignKey("UserId")]
        public User User { get; set; }
        
        [Required, MaxLength(255)] 
        public required string Title { get; set; }
        
        [Required]
        public string Content { get; set; }
        
        [Required, MaxLength(50)]
        public string Language { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}