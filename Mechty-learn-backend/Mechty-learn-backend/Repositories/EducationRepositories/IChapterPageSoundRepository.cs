using Mechty_learn_backend.Models;

namespace Mechty_learn_backend.Repositories;

public interface IChapterPageSoundRepository
{
    Task<int?> CreateChapterPageSound(string chapterPageSoundUrl, int chapterPageId);
    Task<ChapterPageSound?> GetChapterPageSoundById(int chapterPageSoundId);
}