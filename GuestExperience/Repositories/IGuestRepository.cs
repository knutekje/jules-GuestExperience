using GuestExperience.Models;

namespace GuestExperience.Repositories;

public interface IGuestRepository
{
    public Task<Guest> AddGuestAsync(Guest guest);
    public Task<Guest> DeleteGuest(int guestId);
    public Task<Guest> GetGuestByIdAsync(int guestId);
    public Task<List<Guest>> GetGuests();
    public Task<Guest> UpdateGuest(Guest guest);
    public Task<Guest> GetGuestByEmail(string guestEmail);
    
}