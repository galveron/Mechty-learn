using Mechty_learn_backend.Data;
using Mechty_learn_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Mechty_learn_backend.Repositories.EducationRepositories;

public class ChapterPage3DModelRepository : IChapterPage3DModeRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ChapterPage3DModelRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<int?> CreateChapterPage3DModel(string chapterPage3DModelUrl, int chapterPageId)
    {
        var chapterPage3DModelInDb = await _dbContext.ChapterPage3DModels.FirstOrDefaultAsync(c => c.ChapterPageId == chapterPageId);

        if (chapterPage3DModelInDb != null)
        {
            return null;
        }
        
        var chapterPage = await _dbContext.ChapterPages.FirstOrDefaultAsync(c => c.Id == chapterPageId);
        
        if (chapterPage == null)
        {
            return null;
        }
        
        var chapterPage3DModel = new ChapterPage3DModel() {ChapterPageId = chapterPageId, ChapterPage3DModelUrl = chapterPage3DModelUrl, ChapterPage = chapterPage};
        await _dbContext.ChapterPage3DModels.AddAsync(chapterPage3DModel);
        await _dbContext.SaveChangesAsync();

        var newChapterPage3DModel = await _dbContext.ChapterPage3DModels.FirstOrDefaultAsync(c => c.ChapterPageId == chapterPageId);

        return newChapterPage3DModel?.Id;
    }
    
    public async Task<ChapterPage3DModel?> GetChapterPage3DModelById(int chapterPage3DModelId)
    {
        var chapterPage3DModel = await _dbContext.ChapterPage3DModels.FirstOrDefaultAsync(c => c.Id == chapterPage3DModelId);

        return chapterPage3DModel ?? null;
    }
}