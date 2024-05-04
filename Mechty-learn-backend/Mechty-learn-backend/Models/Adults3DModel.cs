namespace Mechty_learn_backend.Models;

public class Adults3DModel
{
    public int Id { get; init; }
    public string Adults3DIconUrl { get; init; }
    public ICollection<Adult> Adults { get; init; } = new List<Adult>();
}