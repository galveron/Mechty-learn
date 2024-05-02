using Microsoft.EntityFrameworkCore;

namespace Mechty_learn_backend.Models;

public class ChapterPage
{
    public int Id { get; set; }
    public ChapterPage3DModel ChapterPage3DModel { get; set; }
    public ChapterPageText ChapterPageText { get; set; }
    public ChapterPageSound ChapterPageSound { get; set; }
}