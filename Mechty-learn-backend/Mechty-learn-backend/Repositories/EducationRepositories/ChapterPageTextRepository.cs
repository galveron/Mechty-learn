using Mechty_learn_backend.Data;
using Mechty_learn_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Mechty_learn_backend.Repositories.EducationRepositories;

public class ChapterPageTextRepository : IChapterPageTextRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ChapterPageTextRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<int?> CreateChapterPageText(string chapterPageTextUrl, int chapterPageId)
    {
        var chapterPageTextInDb = await _dbContext.ChapterPageTexts.FirstOrDefaultAsync(c => c.ChapterPageId == chapterPageId);

        if (chapterPageTextInDb != null)
        {
            return null;
        }
        
        var chapterPage = await _dbContext.ChapterPages.FirstOrDefaultAsync(c => c.Id == chapterPageId);
        
        if (chapterPage == null)
        {
            return null;
        }
        
        var chapterPageText = new ChapterPageText() {ChapterPageId = chapterPageId, ChapterPageTextUrl = chapterPageTextUrl, ChapterPage = chapterPage};
        await _dbContext.ChapterPageTexts.AddAsync(chapterPageText);
        await _dbContext.SaveChangesAsync();

        var newChapterPageText = await _dbContext.ChapterPageTexts.FirstOrDefaultAsync(c => c.ChapterPageId == chapterPageId);

        return newChapterPageText?.Id;
    }
    
    public async Task<ChapterPageText?> GetChapterPageTextById(int chapterPageTextId)
    {
        var chapterPageText = await _dbContext.ChapterPageTexts.FirstOrDefaultAsync(c => c.Id == chapterPageTextId);

        return chapterPageText ?? null;
    }
}