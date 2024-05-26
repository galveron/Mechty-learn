using Mechty_learn_backend.Data;
using Mechty_learn_backend.Models.EducationalModels.EducationalProcess;
using Microsoft.EntityFrameworkCore;

namespace Mechty_learn_backend.Repositories;

public class ProgressRepository : IProgressRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProgressRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int?> CreateLessonProgress(string kidId, int lessonId)
    {
        var kid = await _dbContext.Kids.FirstOrDefaultAsync(k => k.Id == kidId);
        var lesson = await _dbContext.Lessons.FirstOrDefaultAsync(l => l.Id == lessonId);

        if (kid == null || lesson == null)
        {
            return null;
        }
        
        var lessonProgress = new LessonProgress()
        {
            Kid = kid,
            KidId = kidId,
            Lesson = lesson,
            LessonId = lessonId,
            Progress = Progress.Zero
        };
        try
        {
            await _dbContext.LessonProgresses.AddAsync(lessonProgress);
            await _dbContext.SaveChangesAsync();

            var newLessonProgress = 
                await _dbContext.LessonProgresses.FirstOrDefaultAsync(lp => lp.KidId == kidId && lp.LessonId == lessonId);

            return newLessonProgress?.Id;
        }
        catch
        {
            return null;
        }
    }

    public async Task<LessonProgress?> GetLessonProgress(string kidId, int lessonId)
    {
        var lessonProgress =
            await _dbContext.LessonProgresses.FirstOrDefaultAsync(l => l.KidId == kidId && l.LessonId == lessonId);
        return lessonProgress ?? null;
    }
    
    public async Task<int?> CreateChapterProgress(string kidId, int chapterId)
    {
        var kid = await _dbContext.Kids.FirstOrDefaultAsync(k => k.Id == kidId);
        var chapter = await _dbContext.Chapters.FirstOrDefaultAsync(c => c.Id == chapterId);

        if (kid == null || chapter == null)
        {
            return null;
        }
        
        var chapterProgress = new ChapterProgress()
        {
            Kid = kid,
            KidId = kidId,
            Chapter = chapter,
            ChapterId = chapterId,
            Progress = Progress.Zero
        };
        try
        {
            await _dbContext.ChapterProgresses.AddAsync(chapterProgress);
            await _dbContext.SaveChangesAsync();

            var newChapterProgress = 
                await _dbContext.ChapterProgresses.FirstOrDefaultAsync(cp => cp.KidId == kidId && cp.ChapterId == chapterId);

            return newChapterProgress?.Id;
        }
        catch
        {
            return null;
        }
    }
    public async Task<ChapterProgress?> GetChapterProgress(string kidId, int chapterId)
    {
        var chapterProgress =
            await _dbContext.ChapterProgresses.FirstOrDefaultAsync(p => p.KidId == kidId && p.ChapterId == chapterId);
        return chapterProgress ?? null;
    }
    
    public async Task<LessonProgress?> UpdateLessonProgress(string kidId, int lessonId, Progress progress)
    {
        var lessonProgress =
            await _dbContext.LessonProgresses.FirstOrDefaultAsync(l => l.KidId == kidId && l.LessonId == lessonId);
        if (lessonProgress == null)
        {
            return null;
        }

        try
        {
            lessonProgress.Progress = progress;
            await _dbContext.SaveChangesAsync();
        }
        catch
        {
            return null;
        }

        var updatedLessonProgress = 
            await _dbContext.LessonProgresses.FirstOrDefaultAsync(l => l.KidId == kidId && l.LessonId == lessonId);

        return updatedLessonProgress ?? null;
    }
    
    public async Task<ChapterProgress?> UpdateChapterProgress(string kidId, int chapterId, Progress progress)
    {
        var chapterProgress =
            await _dbContext.ChapterProgresses.FirstOrDefaultAsync(l => l.KidId == kidId && l.ChapterId == chapterId);
        if (chapterProgress == null)
        {
            return null;
        }

        try
        {
            chapterProgress.Progress = progress;
            await _dbContext.SaveChangesAsync();
        }
        catch
        {
            return null;
        }

        var updatedChapterProgress = 
            await _dbContext.ChapterProgresses.FirstOrDefaultAsync(l => l.KidId == kidId && l.ChapterId == chapterId);

        return updatedChapterProgress ?? null;
    }
}