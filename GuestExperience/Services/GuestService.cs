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
// TODO HERE WE GO
    public Task<Guest> GetGuestAsync(int guestId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Guest>> GetGuestsAsync()
    {
        throw new NotImplementedException();
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