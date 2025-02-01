using GuestExperience.Models;

using GuestExperience.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuestExperience.Services
{
    public interface IBookingService
    {
   
        Task<IEnumerable<Booking>> GetAllAsync();
        Task<Booking?> GetByIdAsync(int id);
        Task<Booking> CreateAsync(Booking booking);
        Task UpdateAsync(Booking booking);
        Task DeleteAsync(int id);
    }
}
