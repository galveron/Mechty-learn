using Mechty_learn_backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Mechty_learn_backend.Repositories;

public class AdultsRepository : IAdultsRepository
{
    private readonly UserManager<Adult> _userManager;

    public AdultsRepository(UserManager<Adult> userManager)
    {
        _userManager = userManager;
    }

    public async Task<string> AddAdult(string userName, string email, string password)
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
}