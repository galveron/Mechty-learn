using Mechty_learn_backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Mechty_learn_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class KidsController : ControllerBase
{
    private readonly IAdultsRepository _adultsRepository;
    private readonly IKidsRepository _kidsRepository;

    public KidsController(
        IKidsRepository kidsRepository,
        IAdultsRepository adultsRepository)
    {
        _kidsRepository = kidsRepository;
        _adultsRepository = adultsRepository;
    }

    [HttpPost("AddKidByAdultId")]
    public async Task<ActionResult> AddKidByAdultId( string adultId, string kidName, int kidIconId)
    {
        
        var result = await _kidsRepository.AddKid(kidName, adultId, kidIconId);

        return result == null ? Problem("Error in AC 03") : Ok(result);
    }
    
    [HttpPost("AddKidByAdultName")]
    public async Task<ActionResult> AddKidByAdultName( string adultName, string kidName, int kidIconId)
    {
        var adult = await _adultsRepository.GetAdultByName(adultName);
        if (adult == null)
        {
            return Problem("Error in AC 04");
        }
        var result = await _kidsRepository.AddKid(kidName, adult.Id, kidIconId);

        return result == null ? Problem("Error in AC 05"): Ok(result);
    }
}