using GuestExperience.Data;
using GuestExperience.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;

namespace GuestExperience.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly GuestExperienceDbContext _context;

    public BookingRepository(GuestExperienceDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Booking>> GetAllBookings()
    {
        try
        {
            return await _context.Bookings.ToListAsync();
        }
        catch (System.Exception ex)
        {
            throw new AccessViolationException();
        }
        
    }

    public Task<Booking> GetBookingById(int id)
    {
        try
        {
            var result =_context.Bookings.Find(id);
            if (result == null)
            {
                throw new KeyNotFoundException();
            }
            return Task.FromResult(result);
        }
        catch (System.Exception e)
        {
            throw new AccessViolationException();
        }
    }

    public Task<Booking> CreateBooking(Booking booking)
    {
        try
        {
            if (booking == null)
            {
                throw new InputFormatterException();
            }
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            return Task.FromResult(booking);
        }
        catch (System.Exception ex)
        {
            throw new AccessViolationException();
        }
    }

    public Task<Booking> UpdateBooking(Booking booking)
    {
        try
        {
            if (booking == null)
            {
                throw new InputFormatterException();
            }
            _context.Entry(booking).State = EntityState.Modified;
            _context.SaveChanges();
            return Task.FromResult(booking);
        }
        catch (System.Exception e)
        {
            throw new AccessViolationException();
        }
    }

    public Task DeleteBooking(Booking booking)
    {
        try
        {
            if (booking == null)
            {
                throw new InputFormatterException();
            }
            _context.Bookings.Remove(booking);
            _context.SaveChanges();
            return Task.FromResult(0);
    
        }
        catch (System.Exception e)
        {
            throw new AccessViolationException();
        }

    }

    public Task<IEnumerable<Booking>> GetBookingsForGuest(int guestId)
    {
        throw new NotImplementedException();
    }
}