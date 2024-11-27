using Microsoft.EntityFrameworkCore;
using snippets.Models;

namespace snippets.Data;

public class ApiDbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public ApiDbContext(DbContextOptions<ApiDbContext> options, IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(Configuration.GetConnectionString("ApiDbContext"));
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Snippet> Snippets { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<SnippetTag> SnippetTags { get; set; }
}