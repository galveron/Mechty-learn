namespace Mechty_learn_backend.Models;

public class Kids3DModel
{
    public int Id { get; init; }
    public string Kids3DIconUrl { get; init; }
    public ICollection<Kid> Kids { get; init; } = new List<Kid>();
}