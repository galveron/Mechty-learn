using Mechty_learn_backend.Data;
using Mechty_learn_backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Mechty_learn_backend.Repositories;

public class AdultsRepository : IAdultsRepository
{
    private readonly UserManager<Adult> _userManager;
    private readonly ApplicationDbContext _dbContext;

    public AdultsRepository(UserManager<Adult> userManager, ApplicationDbContext dbContext)
    {
        _userManager = userManager;
        _dbContext = dbContext;
    }

    public async Task<string?> AddAdult(string userName, string email, string password, int? adultIconId)
    {
        var adultFromDb1 = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        var adultFromDb2 = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == email);
        
        if (adultFromDb1 != null || adultFromDb2 != null)
        {
            return null;
        }
        
        var adult = new Adult{UserName = userName, Email = email};
        
        var result = await _userManager.CreateAsync(adult, password);
        
        if (!result.Succeeded)
        {
            throw new Exception("Error in AR 01");
        }

        var newAdult = _userManager.Users.First(u => u.UserName == userName);
        
        if (adultIconId == null) return newAdult.Id;
        
        var adults3dIcon = await _dbContext.Adults3DModels.FirstOrDefaultAsync(e => e.Id == adultIconId);
        
        if (adults3dIcon == null) return newAdult.Id;
        
        adults3dIcon.Adults.Add(newAdult);
        _dbContext.Update(adults3dIcon);

        return newAdult.Id;
    }

    public async Task<Adult?> GetAdultById(string adultId)
    {
        var adult = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == adultId);
        return adult;
    }
    
    public async Task<Adult?> GetAdultByName(string adultName)
    {
        var adult = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == adultName);
        return adult;
    }
    
    public async Task<List<Adult>?> GetAllAdult()
    {
        var adults = _userManager.Users.ToList();
        return adults;
    }
}