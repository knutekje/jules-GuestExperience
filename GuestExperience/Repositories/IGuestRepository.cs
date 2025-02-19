using GuestExperience.Models;

namespace GuestExperience.Repositories;

public interface IGuestRepository : IRepository<Guest>
{
    public Task<Guest> GetGuestByEmail(string email);
}