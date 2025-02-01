using GuestExperience.Data;
using GuestExperience.Models;
using Microsoft.EntityFrameworkCore;

namespace GuestExperience.Services;

public class BookingService : IBookingService
{
    private readonly GuestExperienceDbContext _context;

    public  BookingService(GuestExperienceDbContext dbContext)
    {
        _context = dbContext;    
    }
    public async Task<IEnumerable<Booking>> GetAllAsync()
    {
        return await _context.Bookings.ToListAsync();
    }

    public async  Task<Booking?> GetByIdAsync(int id)
    {
        return await _context.Bookings.FindAsync(id);
    }

    public async Task<Booking> CreateAsync(Booking booking)
    {
        if (booking == null)
        {
            throw new ArgumentNullException(nameof(booking));
        } 
        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();
        return booking;

    }

    public Task UpdateAsync(Booking booking)
    {
        if (booking == null)
        {
            throw new ArgumentNullException(nameof(booking));
        }
        _context.Entry(booking).State = EntityState.Modified;
        return _context.SaveChangesAsync();
        

    }

    public Task DeleteAsync(int id)
    {
        var booking = _context.Bookings.Find(id);
        if (booking == null)
        {
            throw new ArgumentNullException(nameof(booking));
        }
        _context.Bookings.Remove(booking);
        return _context.SaveChangesAsync();
        {
            
        }
    }
}