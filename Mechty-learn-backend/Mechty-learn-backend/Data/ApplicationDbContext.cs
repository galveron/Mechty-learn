using Mechty_learn_backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mechty_learn_backend.Data;

public class ApplicationDbContext : IdentityDbContext<Adult>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Adult> Adults { get; init; }
    public DbSet<Kid> Kids { get; init; }
    public DbSet<Kids3DModel> Kids3DModels { get; init; }
    public DbSet<Adults3DModel> Adults3DModels { get; init; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Adult>()
            .HasMany(e => e.Kids)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Kids3DModel>()
            .HasMany(e => e.Kids)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.Entity<Adults3DModel>()
            .HasMany(e => e.Adults)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);
    }
}