using AutoMapper;
using GuestExperience.DTOs;
using GuestExperience.Exception;
using GuestExperience.Models;
using GuestExperience.Services;
using Microsoft.AspNetCore.Mvc;

namespace GuestExperience.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingController : Controller
{
    private readonly  IBookingService _bookingService;
    private readonly IMapper _mapper;

    public BookingController(IBookingService bookingService, IMapper mapper)
    {
        _mapper = mapper;
        _bookingService = bookingService;
    }

    [HttpGet]
    public Task<IEnumerable<Booking>> GetAllBookings()
    {
        try
        {
            return _bookingService.GetAllAsync();
            
        }
        catch (System.Exception ex)
        {
            throw new ControllerException($"Failed to retrieve all booking {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult> CreateBookingAsync([FromBody] BookingDTO bookingDto)
    {
        
            if (bookingDto == null)
            {
                throw new ControllerException("Booking is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var room = await _bookingService.CreateAsync(_mapper.Map<Booking>(bookingDto));
                if (room == null)
                {
                    return BadRequest("Could not create booking");
                }
                
                return Ok(room);            
            }
            catch (System.Exception ex)
            {
                
                throw new ControllerException($"Unable to create booking: {ex.Message}");
            }
            

        
   
    }
    
    [HttpGet("{id}")]
    public async Task<Booking> GetBookingById(int id)
    {
        try
        {
            return  await _bookingService.GetByIdAsync(id);
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
            var result =  _bookingService.DeleteAsync(bookingId);
            return Ok(result);
        }
        catch (System.Exception e)
        {
            throw new AbandonedMutexException();   
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBookingAsync(int bookingId, [FromBody] Booking booking)
    {
        try
        {
            var result = await _bookingService.UpdateAsync(booking);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        catch (System.Exception ex)
        {
            throw new ControllerException($"failed update {ex.Message}");
        }
    }
}