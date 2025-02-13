using GuestExperience.Exception;
using GuestExperience.Models;
using GuestExperience.Repositories;
using Microsoft.AspNetCore.Mvc;

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
        catch (Exception ex)
        {
            throw new ControllerException($"Faild to retrieve all booking {ex}");
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
        catch (Exception e)
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
    public async Task<IActionResult> DeleteBookingAsync(Booking booking)
    {
        try
        {
            var result =  _bookingService.DeleteBookingAsync(booking);
            return Ok(result);
        }
        catch (Exception e)
        {
         throw new AbandonedMutexException();   
        }
    }
}