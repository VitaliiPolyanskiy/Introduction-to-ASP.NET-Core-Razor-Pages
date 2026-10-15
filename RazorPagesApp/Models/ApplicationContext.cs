using Microsoft.EntityFrameworkCore;

namespace RazorPagesApp.Models;

// Щоб підключитися до бази даних через Entity Framework, необхідний контекст даних. 
// Контекст даних являє собою клас, похідний від класу DbContext.
public class ApplicationContext : DbContext
{
    public DbSet<FileModel> Files { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}