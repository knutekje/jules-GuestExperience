using System.Collections;
using GuestExperience.Models;

namespace GuestExperience.Repositories;

public interface IBookingRepository
{
    public Task<IEnumerable<Booking>> GetAllBookingsAsync();
    public Task<Booking> GetBookingByIdAsync(int id);
    public Task<Booking> CreateBookingAsync(Booking booking);
    public Task<Booking> UpdateBookingAsync(Booking booking);
    public Task DeleteBookingAsync(Booking booking);
    public Task<IEnumerable<Booking>> GetBookingsForGuestAsync(int guestId);
}