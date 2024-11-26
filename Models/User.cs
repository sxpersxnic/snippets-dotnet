using System;
using System.ComponentModel.DataAnnotations;

namespace snippets.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(255)] 
        public required string Email { get; set; }
        
        [Required, MaxLength(255)]
        public required string PasswordHash { get; set; }
    }
}