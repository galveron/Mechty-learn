namespace Mechty_learn_backend.Repositories;

public interface IKidsRepository
{
    Task<string?> AddKid(string name, string adultId);
}