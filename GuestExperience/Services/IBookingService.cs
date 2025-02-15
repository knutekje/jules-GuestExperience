using GuestExperience.Models;

public interface IBookingService
{
    
    public Task<Booking> CreateBookingAsync(Booking booking);
    public Task<Booking> UpdateBookingAsync(Booking booking);
    public bool DeleteBookingAsync(int bookingId);
    public Task<IEnumerable<Booking>> GetAllBookingsAsync();
    public Task<Booking> GetBookingById(int id);
    
}