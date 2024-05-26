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

    public async Task<string?> AddKid( string name, string adultId, int kidIconId)
    {
        var kidFromDb = await _dbContext.Kids.FirstOrDefaultAsync(k => k.Name == name);
        
        if (kidFromDb != null)
        {
            return null;
        }
        
        var kiddToAdd = new Kid() { Name = name, AdultId = adultId, Id = $"{adultId}{name}", Kids3DModelId = kidIconId};
        
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
            
            var newKid = await _dbContext.Kids.FirstOrDefaultAsync(k => k.Name == name);
            
            var kids3dIcon = await _dbContext.Kids3DModels.FirstOrDefaultAsync(e => e.Id == kidIconId);
            
            if(kids3dIcon == null || newKid == null) return result.Entity.Id;
            kids3dIcon.Kids.Add(newKid);
            _dbContext.Update(kids3dIcon);
            
            await _dbContext.SaveChangesAsync();

            return result.Entity.Id;
        }
        catch
        {
            throw new Exception("Error in KR 02");
        }
    }
}