using GuestExperience.Data;
using GuestExperience.Exception;
using GuestExperience.Models;
using GuestExperience.Repositories;

namespace GuestExperience.Services;

public class GuestService : IGuestService
{
    private readonly IGuestRepository _repository;

    public GuestService(IGuestRepository repository)
    {
        _repository = repository;
    }
    
    public Task<Guest> AddGuestAsync(Guest guest)
    {
        try
        {
            if (guest == null)
            {
                throw new ServiceException("Invalid guest data");
            }
            var returnedGuest = _repository.AddGuestAsync(guest);
            return returnedGuest;
        }
        catch(System.Exception ex)
        {
            throw new ServiceException($"AddGuestAsync error{ex.Message}");
        }
        
    }
    public Task<Guest> GetGuestAsync(int guestId)
    {
        try
        {
            var  response = _repository.GetGuestByIdAsync(guestId);
            if (response == null)
            {
                throw new ServiceException("No guest found");
            }
            return response;
        }
        catch
        {
            throw new ServiceException($"Unable to get guest with id {guestId}");
        }
        
    }

    public Task<List<Guest>> GetAllGuestAsync()
    {
        try
        {
            var response = _repository.GetAllGuestsAsync();
            if (response == null)
            {
                throw new ServiceException("No guest found");
            }
            return response;
        }
        catch (System.Exception ex)
        {
            throw new ServiceException($"Unable to get all guests{ex.Message}");
        };
    }

    public Task<bool> DeleteGuestAsync(int guestId)
    {
        try
        {
            
            var room = _repository.DeleteGuest(guestId);
            if (room == null)
            {
                throw new ServiceException($"No guest found with id:{guestId}");
            }
            return room;
        }
        catch (System.Exception ex)
        {
            throw new ServiceException($"DeleteGuestAsync error{ex.Message}");
        }
    }

    public Task<Guest> UpdateGuestAsync(Guest guest)
    {
        if (guest == null)
        {
            throw new ServiceException("Invalid guest data");
        }
        try
        {
            var result = _repository.UpdateGuest(guest);
            return result;
        }
        catch
        {
            throw new ServiceException("UpdateGuestAsync error");
        }
    }

    public Task<Guest> GetGuestByEmailAsync(string email)
    {
        if (email == null)
        {
            throw new ServiceException("Email is missing");
        }

        
        try
        {
            var result =  _repository.GetGuestByEmail(email);
            return result;

        }
        catch(System.Exception ex)
        {
            throw new ServiceException($"Unable to get guest by email {ex.Message}");
        }
    }
}