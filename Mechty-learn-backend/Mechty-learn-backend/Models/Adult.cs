using System.Reflection;
using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Mechty_learn_backend.Models;

public class Adult : IdentityUser
{
    public ICollection<Kid> Kids { get; init; } = new List<Kid>();
}