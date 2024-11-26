using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace snippets.Models
{
    public class SnippetTag
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid SnippetId { get; set; }
        
        [ForeignKey("SnippetId")]
        public Snippet Snippet { get; set; }
        
        [Required]
        public Guid TagId { get; set; }
        
        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}