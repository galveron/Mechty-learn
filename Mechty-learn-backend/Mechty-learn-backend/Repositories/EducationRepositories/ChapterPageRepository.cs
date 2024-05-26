using Mechty_learn_backend.Data;
using Mechty_learn_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Mechty_learn_backend.Repositories.EducationRepositories;

public class ChapterPageRepository : IChapterPageRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ChapterPageRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<int?> CreateChapterPage(string chapterPageTitle, string chapterPageDescription, int chapterId)
    {
        var chapterPageInDb = await _dbContext.ChapterPages.FirstOrDefaultAsync(c => c.ChapterPageTitle == chapterPageTitle);

        if (chapterPageInDb != null)
        {
            return null;
        }
        
        var chapterPage = new ChapterPage() { ChapterPageTitle = chapterPageTitle, ChapterPageDescription = chapterPageDescription, ChapterId = chapterId};
        await _dbContext.ChapterPages.AddAsync(chapterPage);
        await _dbContext.SaveChangesAsync();

        var newChapterPage = await _dbContext.ChapterPages.FirstOrDefaultAsync(c => c.ChapterPageTitle == chapterPageTitle);

        return newChapterPage?.Id;
    }
    
    public async Task<ChapterPage?> GetChapterPageById(int chapterPageId)
    {
        var chapterPage = await _dbContext.ChapterPages.FirstOrDefaultAsync(c => c.Id == chapterPageId);

        return chapterPage ?? null;
    }
}