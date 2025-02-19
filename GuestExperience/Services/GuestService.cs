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
    
    public Task<Guest> CreateAsync(Guest guest)
    {
        try
        {
            if (guest == null)
            {
                throw new ServiceException("Invalid guest data");
            }
            var returnedGuest = _repository.CreateAsync(guest);
            return returnedGuest;
        }
        catch(System.Exception ex)
        {
            throw new ServiceException($"AddGuestAsync error{ex.Message}");
        }
        
    }
    public Task<Guest> GetByIdAsync(int guestId)
    {
        try
        {
            var  response = _repository.GetByIdAsync(guestId);
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

    public Task<IEnumerable<Guest>> GetAllAsync()
    {
        try
        {
            var response = _repository.GetAllAsync();
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

    public Task<bool> DeleteAsync(int guestId)
    {
        try
        {
            
            var room = _repository.DeleteAsync(guestId);
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

    public Task<Guest> UpdateAsync(Guest guest)
    {
        if (guest == null)
        {
            throw new ServiceException("Invalid guest data");
        }
        try
        {
            var result = _repository.UpdateAsync(guest);
            return result;
        }
        catch
        {
            throw new ServiceException("UpdateGuestAsync error");
        }
    }

    public Task<Guest> GetGuestByEmail(string email)
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