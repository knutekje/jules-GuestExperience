using GuestExperience.Exception;
using GuestExperience.Models;
using Microsoft.AspNetCore.Mvc;

namespace GuestExperience.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingController : Controller
{
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpGet]
    public Task<IEnumerable<Booking>> GetAllBookings()
    {
        try
        {
            return _bookingService.GetAllBookingsAsync();
            
        }
        catch (System.Exception ex)
        {
            throw new ControllerException($"Failed to retrieve all booking {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult> CreateBookingAsync([FromBody] Booking booking)
    {
        try
        {
            if (booking == null)
            {
                throw new AbandonedMutexException();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _bookingService.CreateBookingAsync(booking);
            if (result == null)
            {
                return BadRequest("Could not create booking");
            }

            return CreatedAtAction(nameof(GetBookingById), new { id = result.Id }, result);

        }
        catch (System.Exception e)
        {
            throw new AbandonedMutexException();
        }
    }
    
    [HttpGet("{id}")]
    public async Task<Booking> GetBookingById(int id)
    {
        try
        {
            return  await _bookingService.GetBookingById(id);
        }
        catch
        {
            throw new AbandonedMutexException();
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBookingAsync(int bookingId)
    {
        try
        {
            var result =  _bookingService.DeleteBookingAsync(bookingId);
            return Ok(result);
        }
        catch (System.Exception e)
        {
            throw new AbandonedMutexException();   
        }
    }
}