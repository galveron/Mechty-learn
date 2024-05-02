using Mechty_learn_backend.Models;
using Mechty_learn_backend.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Mechty_learn_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class AdultsController : ControllerBase
{
    private readonly IAdultsRepository _adultsRepository;
    private readonly IKidsRepository _kidsRepository;

    public AdultsController(
        IKidsRepository kidsRepository,
        IAdultsRepository adultsRepository)
    {
        _kidsRepository = kidsRepository;
        _adultsRepository = adultsRepository;
    }

    [HttpPost("CreateAdult")]
    public async Task<ActionResult> CreateAdult(string userName, string email, string password)
    {
        var newAdultId = await _adultsRepository.AddAdult(userName, email, password);

        return newAdultId == null ? Problem("Error in AC 01. User name or email is already taken") : Ok(newAdultId);
    }
}