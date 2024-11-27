using System.ComponentModel.DataAnnotations.Schema;

namespace snippets.Models;

public class SnippetTag
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public required Guid SnippetId { get; set; }
    public required Guid TagId { get; set; }
    
    [ForeignKey("SnippetId")]
    public required Snippet Snippet { get; set; }
    
    [ForeignKey("TagId")]
    public required Tag Tag { get; set; }
}