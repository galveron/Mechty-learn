using Mechty_learn_backend.Data;
using Mechty_learn_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Mechty_learn_backend.Repositories.EducationRepositories;

public class LessonRepository : ILessonRepository
{
    private readonly ApplicationDbContext _dbContext;

    public LessonRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<int?> CreateLesson(string lessonTitle, string lessonDescription)
    {
        var lessonInDb = await _dbContext.Lessons.FirstOrDefaultAsync(l => l.LessonTitle == lessonTitle);

        if (lessonInDb != null)
        {
            return null;
        }
        
        var lesson = new Lesson() { LessonTitle = lessonTitle, LessonDescription = lessonDescription };
        await _dbContext.Lessons.AddAsync(lesson);
        await _dbContext.SaveChangesAsync();

        var newLesson = await _dbContext.Lessons.FirstOrDefaultAsync(l => l.LessonTitle == lessonTitle);

        if (newLesson == null)
        {
            throw new Exception("Error in LR 01");
        }
        return newLesson.Id;
    }
    
    public async Task<Lesson?> GetLessonById(int lessonId)
    {
        var lesson = await _dbContext.Lessons.FirstOrDefaultAsync(l => l.Id == lessonId);

        return lesson ?? null;
    }
}