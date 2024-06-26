using Mechty_learn_backend.Models;

namespace Mechty_learn_backend.Repositories.EducationRepositories;

public interface ILessonRepository
{
    Task<int?> CreateLesson(string lessonTitle, string lessonDescription);
    Task<Lesson?> GetLessonById(int lessonId);
}