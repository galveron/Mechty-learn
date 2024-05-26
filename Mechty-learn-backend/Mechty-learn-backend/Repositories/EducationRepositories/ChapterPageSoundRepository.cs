using Mechty_learn_backend.Data;
using Mechty_learn_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Mechty_learn_backend.Repositories.EducationRepositories;

public class ChapterPageSoundRepository : IChapterPageSoundRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ChapterPageSoundRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<int?> CreateChapterPageSound(string chapterPageSoundUrl, int chapterPageId)
    {
        var chapterPageSoundInDb = await _dbContext.ChapterPageSounds.FirstOrDefaultAsync(c => c.ChapterPageId == chapterPageId);

        if (chapterPageSoundInDb != null)
        {
            return null;
        }
        
        var chapterPage = await _dbContext.ChapterPages.FirstOrDefaultAsync(c => c.Id == chapterPageId);
        
        if (chapterPage == null)
        {
            return null;
        }
        
        var chapterPageSound = new ChapterPageSound() {ChapterPageId = chapterPageId, ChapterPageSoundUrl = chapterPageSoundUrl, ChapterPage = chapterPage};
        await _dbContext.ChapterPageSounds.AddAsync(chapterPageSound);
        await _dbContext.SaveChangesAsync();

        var newChapterPageSound = await _dbContext.ChapterPageSounds.FirstOrDefaultAsync(c => c.ChapterPageId == chapterPageId);

        return newChapterPageSound?.Id;
    }
    
    public async Task<ChapterPageSound?> GetChapterPageSoundById(int chapterPageSoundId)
    {
        var chapterPageSound = await _dbContext.ChapterPageSounds.FirstOrDefaultAsync(c => c.Id == chapterPageSoundId);

        return chapterPageSound ?? null;
    }
}