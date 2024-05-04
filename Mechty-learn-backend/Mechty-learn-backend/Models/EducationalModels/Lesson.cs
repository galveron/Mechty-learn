using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Mechty_learn_backend.Models;

public class Lesson
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }
    public string? LessonTitle { get; init; }
    public string? LessonDescription { get; init; }
}