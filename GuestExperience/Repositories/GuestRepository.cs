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
            if (guest == null)
            {
                throw new RepositoryException("Guest data invalid");
            }
            await _context.Guests.AddAsync(guest);
            await _context.SaveChangesAsync();
        }
        catch(System.Exception ex)
        {
            throw new RepositoryException($"Error while adding guest {ex.Message}");
        }

        return guest;
    }

  

    public async Task<bool> DeleteGuest(int guestId)
    {   
        
        try
        {

            var guest = await _context.Guests.FindAsync(guestId);
            if (guest == null)
            {
                return false;
            }
            
            _context.Guests.Remove(guest);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (System.Exception e)
        {
          throw new RepositoryException($"Error while deleting guest{e.Message}");
        }

    }

    public async Task<Guest> GetGuestByIdAsync(int guestId)
    {
        
        try
        {
            var guest = await _context.Guests.FindAsync(guestId);
            if (guest == null)
            {
                throw new RepositoryException("Guest not found");
            }
            return guest;
        }
        catch(System.Exception ex)
        {
            throw new RepositoryException($"Error while getting guest{ex}");
        }
    }

   

    public async Task<List<Guest>> GetAllGuestsAsync()
    {
        try
        {
            var guests = await _context.Guests.ToListAsync();
            if (guests == null)
            {
                throw new RepositoryException("Unable to retrieve guest data");
            }

            return guests;
        }
        catch(System.Exception ex)
        {
            throw new RepositoryException($"Error while getting guests{ex}");
        }
    }

    public async Task<Guest> UpdateGuest(Guest guest)
    {
        try
        {
            if (guest == null)
            {
                throw new RepositoryException("Guest not found");
            }
            _context.Guests.Update(guest);
            var something = await _context.SaveChangesAsync();
            return guest;
        }
        catch(System.Exception ex)
        {
            throw new RepositoryException($"Error while updating guest {ex.Message}");
        }
    }

    public async Task<Guest> GetGuestByEmail(string email)
    {
        if (email == null)
        {
            throw new RepositoryException("no valid email provided");
        }
        try
        {
            var guest =  _context.Guests.FirstOrDefault(guest => guest.Email == email);
            if (guest == null)
            {
                throw new RepositoryException($"No guest with email {email} found");
            }
            return guest;
        }
        catch (System.Exception ex)
        {
            throw new RepositoryException($"Error while getting guest {ex}");
        }

    }
}