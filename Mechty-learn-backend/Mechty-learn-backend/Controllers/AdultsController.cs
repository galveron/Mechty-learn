using Mechty_learn_backend.Models;
using Mechty_learn_backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Mechty_learn_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdultsController : ControllerBase
{
    private readonly IAdultsRepository _adultsRepository;

    public AdultsController(
        IAdultsRepository adultsRepository)
    {
        _adultsRepository = adultsRepository;
    }

    [HttpPost("CreateAdult")]
    public async Task<ActionResult> CreateAdult(string userName, string email, string password, int adultIconId)
    {
        var newAdultId = await _adultsRepository.AddAdult(userName, email, password, adultIconId);

        return newAdultId == null ? Problem("Error in AC 01. User name or email is already taken") : Ok(newAdultId);
    }

    [HttpGet("GetAdultById")]
    public async Task<ActionResult<Adult>> GetAdultById(string id)
    {
        var adult = await _adultsRepository.GetAdultById(id);

        var demoAdult = new Adult{UserName = "userName", Email = "email@email.com"};

        return adult == null ? Problem("Error in AC 02.", statusCode:418) : Ok(demoAdult);
    }
}