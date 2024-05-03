using Microsoft.AspNetCore.Identity;

namespace Mechty_learn_backend.Models;

public class Adult : IdentityUser
{
    public ICollection<Kid> Kids { get; init; } = new List<Kid>();
    public int? Adults3DModelId { get; init; }
}