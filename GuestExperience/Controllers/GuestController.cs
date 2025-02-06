using GuestExperience.Exception;
using GuestExperience.Models;
using GuestExperience.Services;
using Microsoft.AspNetCore.Mvc;

namespace GuestExperience.Controllers;

[ApiController]
[Route("[controller]")]
public class GuestController: ControllerBase
{
    private readonly IGuestService _guestService;

    public GuestController(IGuestService guestService)
    {
        _guestService = guestService;
    }

    [HttpGet]
    public async Task<List<Guest>> GetAsync()
    {
        return await _guestService.GetAllGuestAsync();
    }

    [HttpPost]
    public async Task<IActionResult> CreateGuest([FromBody] Guest guest)
    {
        if(guest == null)
        {
            return BadRequest("Room data is missing");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var addedGuest = await _guestService.AddGuestAsync(guest);
            if (addedGuest == null)
            {
                return StatusCode(500, "Failed to add guest");
            }

            return CreatedAtAction(nameof(GetGuestByIdAsync), new { id = addedGuest.Id }, addedGuest);
        }
        catch(System.Exception e)
        {
            throw  new GuestServiceException("Failed to add guest", e);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<Guest> GetGuestByIdAsync(int id)
    {
        try
        {
            var loadedGuest = await _guestService.GetGuestAsync(id);
            return loadedGuest;
        }
        catch(System.Exception ex)
        {
            throw new GuestServiceException("Failed to get guest", ex);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateGuest([FromBody] Guest guest)
    {
        if (guest == null)
        {
            throw new GuestServiceException("Guest data is missing");
        }
        try
        {
            
            var result = await _guestService.UpdateGuestAsync(guest);
            return Ok(result);
        }
        catch(System.Exception ex)
        {
            throw new GuestServiceException("Failed to update guest", ex);
        }
    }

    [HttpGet("{email}")]
    public async Task<IActionResult> GetGuestByEmailAsync(string email)
    {
        try
        { 
            var result = await _guestService.GetGuestByEmailAsync(email);
            return Ok(result);

        }
     
        catch(System.Exception e)
        {
            throw new GuestServiceException("Failed to get guest", e);
        }
    }

}