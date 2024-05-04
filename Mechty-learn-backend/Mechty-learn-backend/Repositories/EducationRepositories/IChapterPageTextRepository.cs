using Mechty_learn_backend.Models;

namespace Mechty_learn_backend.Repositories;

public interface IChapterPageTextRepository
{
    Task<int?> CreateChapterPageText(string chapterPageTextUrl, int chapterPageId);
    Task<ChapterPageText> GetChapterPageTextById(int chapterPageTextId);
}