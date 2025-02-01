using GuestExperience.Data;
using GuestExperience.Models;
using GuestExperience.Services;

namespace GuestExperience.Controllers;

public class BookingController
{
    private readonly IBookingService _bookingService;
    public BookingController(BookingService bookingService)
    {
        _bookingService = bookingService;
    }

    public async Task<IEnumerable<Booking>> GetAllAsync()
    {
        return await _bookingService.GetAllAsync();
    }

    public async Task<Booking?> GetAsync(int id)
    {
        return await _bookingService.GetByIdAsync(id);
    }

    public async Task<Booking> AddAsync(Booking booking)
    {
        ArgumentNullException.ThrowIfNull(booking);
        await _bookingService.CreateAsync(booking);
        return booking;
    }

    public async Task<Booking> UpdateAsync(Booking booking)
    {
        ArgumentNullException.ThrowIfNull(booking);
        await _bookingService.UpdateAsync(booking);
        return booking;
    }

    public async Task<Booking> DeleteAsync(int id)
    {
        ArgumentNullException.ThrowIfNull(id);
        await _bookingService.DeleteAsync(id);
        return null;
    }
    
}