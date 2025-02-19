using GuestExperience.Models;

namespace GuestExperience.Services;

public interface IGuestService : IService<Guest>
{
    public Task<Guest> GetGuestByEmail(string email);
}