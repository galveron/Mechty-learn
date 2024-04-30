using Mechty_learn_backend.Models;
using Mechty_learn_backend.Models.EducationalModels.EducationalProcess;
using Microsoft.EntityFrameworkCore;

namespace Mechty_learn_backend.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Adult> Adults { get; set; }
    public DbSet<Kid> Kids { get; set; }
    
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Chapter> Chapters { get; set; }
    public DbSet<ChapterPage> ChapterPages { get; set; }
    public DbSet<ChapterPage3DModel> ChapterPage3DModels { get; set; }
    public DbSet<ChapterPageSound> ChapterPageSounds { get; set; }
    public DbSet<ChapterPageText> ChapterPageTexts { get; set; }
    
    public DbSet<ChapterProgress> ChapterProgresses { get; set; }
    public DbSet<LessonProgress> LessonProgresses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Adult>()
            .HasMany(e => e.Kids)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Adult>()
            .HasOne(e => e.Icon)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.Entity<Kid>()
            .HasOne(e => e.Icon)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.Entity<ChapterProgress>()
            .HasOne(e => e.Kid)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.Entity<LessonProgress>()
            .HasOne(e => e.Kid)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.Entity<Lesson>()
            .HasMany(e => e.Chapters)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<Chapter>()
            .HasMany(e => e.ChapterPages)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<ChapterPage>()
            .HasOne(e => e.ThreeDModel)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<ChapterPage>()
            .HasOne(e => e.Sound)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<ChapterPage>()
            .HasOne(e => e.Text)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
    }
}