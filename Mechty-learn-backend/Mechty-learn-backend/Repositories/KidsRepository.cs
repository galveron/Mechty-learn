using Mechty_learn_backend.Data;
using Mechty_learn_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Mechty_learn_backend.Repositories;

public class KidsRepository : IKidsRepository
{
    private readonly ApplicationDbContext _dbContext;

    public KidsRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string?> AddKid( string name, string adultId)
    {
        var kidFromDb = await _dbContext.Kids.FirstOrDefaultAsync(k => k.Name == name);
        
        if (kidFromDb != null)
        {
            return null;
        }
        
        var kiddToAdd = new Kid() { Name = name, AdultId = adultId, Id = $"{adultId}{name}"};
        
        var adultFromDb = await _dbContext.Adults.FirstOrDefaultAsync(a => a.Id == adultId);

        if (adultFromDb == null)
        {
            throw new Exception("Error in KR 01");
        }

        try
        {
            adultFromDb.Kids.Add(kiddToAdd);
            _dbContext.Update(adultFromDb);
            var result = await _dbContext.Kids.AddAsync(kiddToAdd);
            await _dbContext.SaveChangesAsync();

            return result.Entity.Id;
        }
        catch
        {
            throw new Exception("Error in KidsRepository");
        }
    }
}