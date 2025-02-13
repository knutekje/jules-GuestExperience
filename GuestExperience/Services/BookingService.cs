using GuestExperience.Models;
using GuestExperience.Repositories;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;
    public BookingService(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public Task<Booking> CreateBookingAsync(Booking booking)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(booking);
            _bookingRepository.CreateBookingAsync(booking);
            return Task.FromResult(booking);
        }
        catch (Exception e)
        {
            throw;
        }

    }

    public Task<Booking> UpdateBookingAsync(Booking booking)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(booking);
            _bookingRepository.UpdateBookingAsync(booking);
            return Task.FromResult(booking);
        }
        catch (Exception e)
        {
            throw new AbandonedMutexException();
        }
    }

    public Task DeleteBookingAsync(Booking booking)
    {
        try
        {
            
            _bookingRepository.DeleteBookingAsync(booking);
            return Task.CompletedTask;
        }
        catch (Exception e)
        {
            
            throw new AbandonedMutexException();

        }
    }

    public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
    {
        try
        {
         return  await  _bookingRepository.GetAllBookingsAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Booking> GetBookingById(int id)
    {
        try
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return await _bookingRepository.GetBookingByIdAsync(id);

        }
        catch
        {
            throw new KeyNotFoundException();
        }
    }
}