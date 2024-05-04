using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Mechty_learn_backend.Models;

[PrimaryKey(nameof(Id),nameof(LessonId))]
public class Chapter
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }
    public int LessonId { get; init; }
    public ICollection? ChapterPages { get; } = new List<ChapterPage>();
    public string? ChapterTitle { get; init; }
    public string? ChapterDescription { get; init; }
}