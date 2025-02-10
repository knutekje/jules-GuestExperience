using System.Collections;
using GuestExperience.Models;

namespace GuestExperience.Repositories;

public interface IBookingRepository
{
    public Task<IEnumerable<Booking>> GetAllBookings();
    public Task<Booking> GetBookingById(int id);
    public Task<Booking> CreateBooking(Booking booking);
    public Task<Booking> UpdateBooking(Booking booking);
    public Task DeleteBooking(Booking booking);
    public Task<IEnumerable<Booking>> GetBookingsForGuest(int guestId);
}