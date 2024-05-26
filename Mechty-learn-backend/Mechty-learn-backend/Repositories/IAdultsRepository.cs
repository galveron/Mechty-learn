using Mechty_learn_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mechty_learn_backend.Repositories;

public interface IAdultsRepository
{
    Task<string?> AddAdult(string userName, string email, string password, int? adultIconId);
    Task<Adult?> GetAdultById(string adultId);
    Task<Adult?> GetAdultByName(string adultName);
}