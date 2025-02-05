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
            var returnedGuest = _repository.AddGuestAsync(guest);
            return returnedGuest;
        }
        catch(System.Exception ex)
        {
            throw new GuestServiceException("AddGuestAsync error", ex);
        }
        
    }
    public Task<Guest> GetGuestAsync(int guestId)
    {
        try
        {
            var  response = _repository.GetGuestByIdAsync(guestId);
            return response;
        }
        catch
        {
            throw new GuestServiceException($"Unable to get guest with id {guestId}");
        }
        
    }

    public Task<List<Guest>> GetAllGuestAsync()
    {
        try
        {
            var response = _repository.GetGuests();
            return response;
        }
        catch
        {
            throw new GuestServiceException("Unable to get all guests");
        };
    }

    public Task DeleteGuestAsync(int guestId)
    {
        throw new NotImplementedException();
    }

    public Task<Guest> UpdateGuestAsync(Guest guest)
    {
        throw new NotImplementedException();
    }
}