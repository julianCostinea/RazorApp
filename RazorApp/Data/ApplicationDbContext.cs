using Microsoft.EntityFrameworkCore;
using RazorApp.Model;

namespace RazorApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }
    public DbSet<Category> Category { get; set; }
}