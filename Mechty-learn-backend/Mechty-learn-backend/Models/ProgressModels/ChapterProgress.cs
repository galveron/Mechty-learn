using System.ComponentModel.DataAnnotations.Schema;
using Mechty_learn_backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Mechty_learn_backend.Models.EducationalModels.EducationalProcess;

[PrimaryKey(nameof(Id), nameof(KidId), nameof(ChapterId))]
public class ChapterProgress
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }
    public string KidId { get; init; }
    public Kid Kid { get; init; }
    public int ChapterId { get; init; }
    public Chapter Chapter { get; init; }
    public Progress Progress { get; set; }
}