using Mechty_learn_backend.Data;
using Mechty_learn_backend.Models.EducationalModels.EducationalProcess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Mechty_learn_backend.Models;

[PrimaryKey(nameof(Id), nameof(AdultId))]
public class Kid
{
    public string Id { get; init; } //Adult id + kid name
    public string AdultId { get; init; }
    public string Name { get; init; }
    public int Score { get; init; }= 0;
    public Progress KidProgress { get; init; } = Progress.zero;
}