using Mechty_learn_backend.Models;

namespace Mechty_learn_backend.Repositories;

public interface IChapterPage3DModeRepository
{
    Task<int?> CreateChapterPage3DModel(string chapterPage3DModelUrl, int chapterPageId);
    Task<ChapterPage3DModel?> GetChapterPage3DModelById(int chapterPage3DModelId);
}