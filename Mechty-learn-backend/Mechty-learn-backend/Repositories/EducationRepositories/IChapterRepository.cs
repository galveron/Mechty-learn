using Mechty_learn_backend.Models;

namespace Mechty_learn_backend.Repositories;

public interface IChapterRepository
{
    Task<int?> CreateChapter(string chapterTitle, string chapterDescription, int lessonId);
    Task<Chapter?> GetChapterById(int chapterId);
}