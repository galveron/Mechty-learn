using Mechty_learn_backend.Models;
using Mechty_learn_backend.Models.EducationalModels.EducationalProcess;
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

    public DbSet<Lesson> Lessons { get; init; }
    public DbSet<Chapter> Chapters { get; init; }
    public DbSet<ChapterPage> ChapterPages { get; init; }
    public DbSet<ChapterPage3DModel> ChapterPage3DModels { get; init; }
    public DbSet<ChapterPageSound> ChapterPageSounds { get; init; }
    public DbSet<ChapterPageText> ChapterPageTexts { get; init; }

    public DbSet<ChapterProgress> ChapterProgresses { get; init; }
    public DbSet<LessonProgress> LessonProgresses { get; init; }

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

        builder.Entity<Lesson>()
            .HasMany<Chapter>()
            .WithOne()
            .HasForeignKey(e => e.LessonId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Chapter>()
            .HasMany<ChapterPage>()
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<ChapterPageSound>()
            .HasOne(e => e.ChapterPage)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.Entity<ChapterPageText>()
            .HasOne(e => e.ChapterPage)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.Entity<ChapterPage3DModel>()
            .HasOne(e => e.ChapterPage)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.Entity<ChapterProgress>()
            .HasOne(e => e.Chapter)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.Entity<ChapterProgress>()
            .HasOne(e => e.Kid)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.Entity<LessonProgress>()
            .HasOne(e => e.Lesson)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.Entity<LessonProgress>()
            .HasOne(e => e.Kid)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);
    }
}