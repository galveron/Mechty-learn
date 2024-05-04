using System.ComponentModel.DataAnnotations.Schema;
using Mechty_learn_backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Mechty_learn_backend.Models.EducationalModels.EducationalProcess;

[PrimaryKey(nameof(Id),nameof(KidId), nameof(LessonId))]
public class LessonProgress
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }
    public Kid Kid { get; init; }
    public string KidId { get; init; }
    public Lesson Lesson { get; init; }
    public int LessonId { get; init; }
    public Progress Progress { get; set; }
}