using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace snippets.Models
{
    public class Tag
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [MaxLength(7), DefaultValue("#B8B8B8")]
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}