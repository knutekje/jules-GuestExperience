using System.Collections;
using GuestExperience.Models;

namespace GuestExperience.Repositories;

public interface IBookingRepository
{
    public Task<IEnumerable<Booking>> GetAllBookingsAsync();
    public Task<Booking> GetBookingByIdAsync(int id);
    public Task<Booking> CreateBookingAsync(Booking booking);
    public Task<Booking> UpdateBookingAsync(Booking booking);
    public Task<bool> DeleteBookingAsync(int bookingId);
    public Task<IEnumerable<Booking>> GetBookingsForGuestAsync(int guestId);
}