using Mechty_learn_backend.Data;
using Mechty_learn_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Mechty_learn_backend.Repositories;

public class ChapterRepository : IChapterRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ChapterRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<int?> CreateChapter(string chapterTitle, string chapterDescription, int lessonId)
    {
        var chapterInDb = await _dbContext.Chapters.FirstOrDefaultAsync(c => c.ChapterTitle == chapterTitle);

        if (chapterInDb != null)
        {
            return null;
        }
        
        var chapter = new Chapter() { ChapterTitle = chapterTitle, ChapterDescription = chapterDescription, LessonId = lessonId};
        await _dbContext.Chapters.AddAsync(chapter);
        await _dbContext.SaveChangesAsync();

        var newChapter = await _dbContext.Chapters.FirstOrDefaultAsync(c => c.ChapterTitle == chapterTitle);

        if (newChapter == null)
        {
            throw new Exception("Error in CR 01");
        }
        return newChapter.Id;
    }
    
    public async Task<Chapter> GetChapterById(int chapterId)
    {
        var chapter = await _dbContext.Chapters.FirstOrDefaultAsync(c => c.Id == chapterId);

        if (chapter == null)
        {
            throw new Exception("Error in CR 02");
        }

        return chapter;
    }
}