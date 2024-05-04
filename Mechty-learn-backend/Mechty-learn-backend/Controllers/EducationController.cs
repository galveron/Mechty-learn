using Mechty_learn_backend.Models;
using Mechty_learn_backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Mechty_learn_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class EducationController : ControllerBase
{
    private readonly ILessonRepository _lessonRepository;
    private readonly IChapterRepository _chapterRepository;
    private readonly IChapterPageRepository _chapterPageRepository;
    private readonly IChapterPageSoundRepository _chapterPageSoundRepository;
    private readonly IChapterPageTextRepository _chapterPageTextRepository;
    private readonly IChapterPage3DModeRepository _chapterPage3DModeRepository;

    public EducationController(ILessonRepository lessonRepository, IChapterRepository chapterRepository, IChapterPageRepository chapterPageRepository, IChapterPageSoundRepository chapterPageSoundRepository, IChapterPageTextRepository chapterPageTextRepository, IChapterPage3DModeRepository chapterPage3DModeRepository)
    {
        _lessonRepository = lessonRepository;
        _chapterRepository = chapterRepository;
        _chapterPageRepository = chapterPageRepository;
        _chapterPageSoundRepository = chapterPageSoundRepository;
        _chapterPageTextRepository = chapterPageTextRepository;
        _chapterPage3DModeRepository = chapterPage3DModeRepository;
    }

    [HttpPost("CreateLesson")]
    public async Task<ActionResult<int>> CreateLesson(string lessonTitle, string lessonDescription)
    {
        var result = await _lessonRepository.CreateLesson(lessonTitle, lessonDescription);

        return result == null ? Problem("Error in EC 01") : Ok(result);
    }
    
    [HttpPost("CreateChapter")]
    public async Task<ActionResult<int>> CreateChapter(string chapterTitle, string chapterDescription, int lessonId)
    {
        var result = await _chapterRepository.CreateChapter(chapterTitle, chapterDescription, lessonId);

        return result == null ? Problem("Error in EC 02") : Ok(result);
    }
    
    [HttpPost("CreateChapterPage")]
    public async Task<ActionResult<int>> CreateChapterPage(string chapterPageTitle, string chapterPageDescription, int chapterId)
    {
        var result = await _chapterPageRepository.CreateChapterPage(chapterPageTitle, chapterPageDescription, chapterId);

        return result == null ? Problem("Error in EC 03") : Ok(result);
    }
    
    [HttpPost("CreateChapterPageSound")]
    public async Task<ActionResult<int>> CreateChapterPageSound(string chapterPageSoundUrl, int chapterPageId)
    {
        var result = await _chapterPageSoundRepository.CreateChapterPageSound(chapterPageSoundUrl, chapterPageId);

        return result == null ? Problem("Error in EC 04") : Ok(result);
    }
    
    [HttpPost("CreateChapterPageText")]
    public async Task<ActionResult<int>> CreateChapterPageText(string chapterPageTextUrl, int chapterPageId)
    {
        var result = await _chapterPageTextRepository.CreateChapterPageText(chapterPageTextUrl, chapterPageId);

        return result == null ? Problem("Error in EC 05") : Ok(result);
    }
    
    [HttpPost("CreateChapterPage3DModel")]
    public async Task<ActionResult<int>> CreateChapterPage3DModel(string chapterPage3DModelUrl, int chapterPageId)
    {
        var result = await _chapterPage3DModeRepository.CreateChapterPage3DModel(chapterPage3DModelUrl, chapterPageId);

        return result == null ? Problem("Error in EC 06") : Ok(result);
    }
    
    [HttpGet("GetLessonById")]
    public async Task<ActionResult<Lesson>> GetLessonById(int lessonId)
    {
        var result = await _lessonRepository.GetLessonById(lessonId);

        return result == null ? Problem("Error in EC 07") : Ok(result);
    }
    
    [HttpGet("GetChapterById")]
    public async Task<ActionResult<Lesson>> GetChapterById(int chapterId)
    {
        var result = await _chapterRepository.GetChapterById(chapterId);

        return result == null ? Problem("Error in EC 08") : Ok(result);
    }
    
    [HttpGet("GetChapterPageById")]
    public async Task<ActionResult<Lesson>> GetChapterPageById(int chapterPageId)
    {
        var result = await _chapterPageRepository.GetChapterPageById(chapterPageId);

        return result == null ? Problem("Error in EC 09") : Ok(result);
    }
    
    [HttpGet("GetChapterPageSoundById")]
    public async Task<ActionResult<Lesson>> GetChapterPageSoundById(int chapterPageSoundId)
    {
        var result = await _chapterPageSoundRepository.GetChapterPageSoundById(chapterPageSoundId);

        return result == null ? Problem("Error in EC 10") : Ok(result);
    }
    
    [HttpGet("GetChapterPageTextById")]
    public async Task<ActionResult<Lesson>> GetChapterPageTextById(int chapterPageTextId)
    {
        var result = await _chapterPageTextRepository.GetChapterPageTextById(chapterPageTextId);

        return result == null ? Problem("Error in EC 11") : Ok(result);
    }
    
    [HttpGet("GetChapterPage3DModelById")]
    public async Task<ActionResult<Lesson>> GetChapterPage3DModelById(int chapterPage3DModelId)
    {
        var result = await _chapterPage3DModeRepository.GetChapterPage3DModelById(chapterPage3DModelId);

        return result == null ? Problem("Error in EC 12") : Ok(result);
    }
}