using System.Reflection;
using Azure.Identity;
using Microsoft.AspNetCore.Identity;

namespace Mechty_learn_backend.Models;

public class Adult : IdentityUser
{
    public List<Kid> Kids = new List<Kid>();
    public User3DIcon Icon;
}