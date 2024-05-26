using Mechty_learn_backend.Models;

namespace Mechty_learn_backend.Repositories;

public interface IChapterPageRepository
{
    Task<int?> CreateChapterPage(string chapterPageTitle, string chapterPageDescription, int chapterId);
    Task<ChapterPage?> GetChapterPageById(int chapterPageId);
}