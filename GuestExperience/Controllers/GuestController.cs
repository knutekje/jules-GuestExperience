using System.Runtime.Serialization;
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
    public async Task<IEnumerable<Guest>> GetAllGuestsAsync()
    {
        try
        {
            
            return await _guestService.GetAllAsync();
        }
        catch (System.Exception ex)
        {
            
            throw new ServiceException($"Failed to get guests {ex.Message}.");
        }
        
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
            var addedGuest = await _guestService.CreateAsync(guest);
            if (addedGuest == null)
            {
                return StatusCode(500, "Failed to add guest");
            }

            return CreatedAtAction(nameof(GetGuestByIdAsync), new { id = addedGuest.Id }, addedGuest);
        }
        catch(System.Exception ex)
        {
            throw  new SerializationException($"Failed to add guest{ex.Message}");
        }
    }

    [HttpGet("{id:int}")]
    public async Task<Guest> GetGuestByIdAsync(int id)
    {
        try
        {
            var loadedGuest = await _guestService.GetByIdAsync(id);
            if (loadedGuest == null)
            {
                throw new SerializationException($"Room with id {id} was not found");
            }
            return loadedGuest;
        }
        catch(System.Exception ex)
        {
            throw new SerializationException("Failed to get guest", ex);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] Guest guest)
    {
        if (guest == null)
        {
            throw new GuestServiceException("Guest data is missing");
        }
        try
        {
            
            var result = await _guestService.UpdateAsync(guest);
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
            var result = await _guestService.GetGuestByEmail(email);
            return Ok(result);

        }
     
        catch(System.Exception e)
        {
            throw new GuestServiceException("Failed to get guest", e);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteGuest([FromBody] int guestId)
    {
        try
        {
            await _guestService.DeleteAsync(guestId);
            return Ok();/**/
        }
        catch (System.Exception ex)
        {
                throw new ControllerException($"Exception while trying to delete guest {ex.Message}");
        }
    }

}