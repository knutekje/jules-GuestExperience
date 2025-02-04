using GuestExperience.Models;

namespace GuestExperience.Services;

public interface IGuestService
{
    public Task<Guest> AddGuestAsync(Guest guest);
    public Task<Guest> GetGuestAsync(int guestId);
    public Task<List<Guest>> GetGuestsAsync();
    public Task DeleteGuestAsync(int guestId);
    public Task<Guest> UpdateGuestAsync(Guest guest);
}