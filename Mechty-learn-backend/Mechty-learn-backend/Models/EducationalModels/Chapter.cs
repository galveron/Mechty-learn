using Microsoft.EntityFrameworkCore;

namespace Mechty_learn_backend.Models;

public class Chapter
{
    public int Id { get; set; }
    public ICollection<ChapterPage> ChapterPages { get; } = new List<ChapterPage>();
}