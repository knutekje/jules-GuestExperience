using GuestExperience.Models;

public interface IBookingService
{
    
    public Task<Booking> CreateBookingAsync(Booking booking);
    public Task<Booking> UpdateBookingAsync(Booking booking);
    public Task DeleteBookingAsync(Booking booking);
    public Task<IEnumerable<Booking>> GetAllBookingsAsync();
    public Task<Booking> GetBookingById(int id);
    
}