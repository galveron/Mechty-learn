using Mechty_learn_backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Mechty_learn_backend.Models.EducationalModels.EducationalProcess;

[PrimaryKey(nameof(Id), nameof(KidId), nameof(ChapterId))]
public class ChapterProgress
{
    public int Id { get; init; }
    public string KidId { get; init; }
    public int ChapterId { get; init; }
    public Progress Progress { get; init; }
}