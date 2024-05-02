using Mechty_learn_backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mechty_learn_backend.Data;

public class ApplicationDbContext : IdentityDbContext<Adult>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Adult> Adults { get; set; }
    public DbSet<Kid> Kids { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Adult>()
            .HasMany(e => e.Kids)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
       
    }
}