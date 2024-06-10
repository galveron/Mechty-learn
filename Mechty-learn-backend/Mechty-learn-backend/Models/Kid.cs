using Mechty_learn_backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Mechty_learn_backend.Models;

[PrimaryKey(nameof(Id), nameof(AdultId))]
public class Kid
{
    public string Id { get; init; } //Adult id + kid name
    public string AdultId { get; init; }
    public string Name { get; init; }
    public int Score { get; init; } = 0;
    public Progress KidProgress { get; init; } = Progress.Zero;
    public int? Kids3DModelId { get; init; }
}