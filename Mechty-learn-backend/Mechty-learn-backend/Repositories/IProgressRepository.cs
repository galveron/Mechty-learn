using Mechty_learn_backend.Data;
using Mechty_learn_backend.Models.EducationalModels.EducationalProcess;

namespace Mechty_learn_backend.Repositories;

public interface IProgressRepository
{
    Task<int?> CreateLessonProgress(string kidId, int lessonId);
    Task<LessonProgress?> GetLessonProgress(string kidId, int lessonId);
    Task<int?> CreateChapterProgress(string kidId, int chapterId);
    Task<ChapterProgress?> GetChapterProgress(string kidId, int chapterId);
    Task<LessonProgress?> UpdateLessonProgress(string kidId, int lessonId, Progress progress);
    Task<ChapterProgress?> UpdateChapterProgress(string kidId, int chapterId, Progress progress);
}