using GuestExperience.Exception;
using GuestExperience.Models;
using GuestExperience.Repositories;
using GuestExperience.Services;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;
    public BookingService(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public async Task<Booking> CreateAsync(Booking booking)
    {
        if (booking == null)
        {
            throw new ServiceException("Booking data is invalid");
        }
        try
        {
            return await _bookingRepository.CreateAsync(booking);
            
        }
        catch (Exception ex)
        {
            throw new ServiceException($"Error while creating booking {ex.Message}");
        }

    }
//TODO from here
    public async Task<Booking> UpdateAsync(Booking booking)
    {
        if (booking == null)
        {
            throw new ServiceException("Booking update data is invalid");
        }
        try
        {
            var result = await _bookingRepository.UpdateAsync(booking);
            if (result == null)
            {
                throw new ServiceException($"Error while updating booking {booking.Id}");
            }
            return result;
        }
        catch (Exception ex)
        {
            throw new ServiceException($"Error while updating booking data{ex.Message}");
        }
    }

    public async Task<bool> DeleteAsync(int bookingId)
    {
        if (bookingId == null)
        {
            throw new ServiceException("Booking data is invalid");
        }

        try
        {
            
            var result = _bookingRepository.DeleteAsync(bookingId);
            if (result == null)
            {
                throw new ServiceException($"Error while deleting booking {bookingId}");
            }
            
            return true;            
        }
        catch (Exception e)
        {
            
            throw new ServiceException($"Error while deleting booking data {e.Message}");

        }
    }

    public async Task<IEnumerable<Booking>> GetAllAsync()
    {
        try
        {
            var result = await _bookingRepository.GetAllAsync();
            if (result == null)
            {
                throw new ServiceException("No bookings found");
            }
            return result;
        }
        catch (Exception ex)
        {
            throw new ServiceException($"Error while getting all bookings {ex.Message}");
        }
    }

    public async Task<Booking> GetByIdAsync(int id)
    {
        
        try
        {
            

            var result = await _bookingRepository.GetByIdAsync(id);
            if (result == null)
            {
                throw new ServiceException($"No booking found with id {id}");
            }
            return result;

        }
        catch( Exception ex)
        {
            throw new ServiceException($"Error while getting booking data {ex.Message}");
        }
    }
}