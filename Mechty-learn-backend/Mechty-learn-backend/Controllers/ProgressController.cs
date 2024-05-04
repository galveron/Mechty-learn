using Mechty_learn_backend.Data;
using Mechty_learn_backend.Models.EducationalModels.EducationalProcess;
using Mechty_learn_backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Mechty_learn_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class ProgressController : ControllerBase
{
    private readonly IProgressRepository _progressRepository;

    public ProgressController(IProgressRepository progressRepository)
    {
        _progressRepository = progressRepository;
    }

    //CRATE
    
    [HttpPost("CreateLessonProgress")]
    public async Task<ActionResult<int>> CreateLessonProgress(string kidId, int lessonId)
    {
        var result = await _progressRepository.CreateLessonProgress(kidId, lessonId);

        return result == null ? Problem("Error in PC 01") : Ok(result);
    }
    
    [HttpPost("CreateChapterProgress")]
    public async Task<ActionResult<int>> CreateChapterProgress(string kidId, int chapterId)
    {
        var result = await _progressRepository.CreateChapterProgress(kidId, chapterId);

        return result == null ? Problem("Error in PC 02") : Ok(result);
    }
    
    //READ
    
    [HttpGet("GetLessonProgress")]
    public async Task<ActionResult<LessonProgress>> GetLessonProgress(string kidId, int lessonProgressId)
    {
        var result = await _progressRepository.GetLessonProgress(kidId, lessonProgressId);

        return result == null ? Problem("Error in PC 03") : Ok(result);
    }
    
    [HttpGet("GetChapterProgress")]
    public async Task<ActionResult<LessonProgress>> GetChapterProgress(string kidId, int chapterProgressId)
    {
        var result = await _progressRepository.GetChapterProgress(kidId, chapterProgressId);

        return result == null ? Problem("Error in PC 04") : Ok(result);
    }
    
    //UPDATE
    
    [HttpPatch("UpdateLessonProgress")]
    public async Task<ActionResult<LessonProgress>> UpdateLessonProgress(string kidId, int lessonProgressId, Progress progress)
    {
        var result = await _progressRepository.UpdateLessonProgress(kidId, lessonProgressId, progress);

        return result == null ? Problem("Error in PC 05") : Ok(result);
    }
    
    [HttpPatch("UpdateChapterProgress")]
    public async Task<ActionResult<ChapterProgress>> UpdateChapterProgress(string kidId, int chapterProgressId, Progress progress)
    {
        var result = await _progressRepository.UpdateChapterProgress(kidId, chapterProgressId, progress);

        return result == null ? Problem("Error in PC 06") : Ok(result);
    }
}