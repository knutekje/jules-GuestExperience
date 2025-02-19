using GuestExperience.Data;
using GuestExperience.Exception;
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
    
    public async Task<IEnumerable<Booking>> GetAllAsync()
    {
        try
        {
            var result = await _context.Bookings.ToListAsync();
            if (result == null)
            {
                throw new RepositoryException("No bookings found");
            }
            return result;
        }
        catch (System.Exception ex)
        {
            throw new RepositoryException($"Error in retrieving bookings{ex.Message}");
        }
        
    }

    public Task<Booking> GetByIdAsync(int id)
    {
        try
        {
            var result =_context.Bookings.Find(id);
            if (result == null)
            {
                throw new RepositoryException($"No booking with id: {id} found");
            }
            return Task.FromResult(result);
        }
        catch (System.Exception ex)
        {
            throw new RepositoryException($"Error in retrieving booking{ex.Message}");
        }
    }

    public Task<Booking> CreateAsync(Booking booking)
    {
        try
        {
            if (booking == null)
            {
                throw new RepositoryException("Booking data is invalid");
            }
        
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            return Task.FromResult(booking);
        }
        catch (System.Exception ex)
        {
            throw new RepositoryException($"Unable to create booking{ex.Message}");
        }
    }

    public Task<Booking> UpdateAsync(Booking booking)
    {
        try
        {
            if (booking == null)
            {
                throw new RepositoryException("Booking data is invalid");
            }
             
            _context.Update(booking);
            _context.SaveChanges();
            return Task.FromResult(booking);
            
        }
        catch (System.Exception ex)
        {
            throw new RepositoryException("Error while updating");
        }
    }

    public async Task<bool> DeleteAsync(int bookingId)
    {
        try
        {
            var booking =  _context.Bookings.Find(bookingId);
            if (booking == null)
            {
                return false;
            }
            _context.Bookings.Remove(booking);
            _context.SaveChanges();
            return true;
        }
        catch (System.Exception ex)
        {
            throw new RepositoryException($"Error while deleting {ex.Message}");
        }

    }

    public Task<IEnumerable<Booking>> GetBookingsForGuestAsync(int guestId)
    {
        throw new NotImplementedException();
    }
}