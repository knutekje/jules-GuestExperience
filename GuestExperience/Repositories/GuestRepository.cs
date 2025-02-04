using GuestExperience.Data;
using GuestExperience.Exception;
using GuestExperience.Models;
using Microsoft.EntityFrameworkCore;

namespace GuestExperience.Repositories;

public class GuestRepository : IGuestRepository
{
    private readonly GuestExperienceDbContext _context;

    public GuestRepository(GuestExperienceDbContext context)
    {
        _context = context;
    }
    public async Task<Guest> AddGuestAsync(Guest guest)
    {
        try
        {
            await _context.Guests.AddAsync(guest);
            await _context.SaveChangesAsync();
        }
        catch(System.Exception ex)
        {
            throw new CreateGuestException("Error while adding guest", ex);
        }

        return guest;
    }

  

    public async Task<Guest> DeleteGuest(int guestId)
    {   
        
        try
        {
            Guest guest = await _context.Guests.FindAsync(guestId) ?? throw new InvalidOperationException();
            _context.Guests.Remove(guest);
            await _context.SaveChangesAsync();
            return guest;
        }
        catch (System.Exception e)
        {
          throw new CreateGuestException("Error while deleting guest", e);
        }

    }

    public async Task<Guest> GetGuest(int guestId)
    {
        var guest = await _context.Guests.FindAsync(guestId) ?? throw new CreateGuestException("Error while getting guest");
        try
        {
            return guest;
        }
        catch(System.Exception e)
        {
            throw new CreateGuestException("Error while getting guest", e);
        }
    }

    public async Task<List<Guest>> GetGuests()
    {
        try
        {
            return await _context.Guests.ToListAsync();
        }
        catch
        {
            throw new CreateGuestException("Error while getting guests");
        }
    }
    
}