using GuestExperience.Exception;
using GuestExperience.Models;
using GuestExperience.Repositories;

namespace GuestExperience.Services;

public class ReservationService : IReservationService
{
private readonly IReservationRepository _reservationRepository;
public ReservationService(IReservationRepository reservationRepository)

{
   _reservationRepository = reservationRepository;
}
public async Task<IEnumerable<Reservation>> GetAllAsync()
{
   try
   {
       var result = await _reservationRepository.GetAllAsync();
       if (result == null)
       {
           throw new ServiceException("Reservations not found");
       }
       return result;
   }
   catch (System.Exception ex)
   {
       throw new ServiceException($"Error while getting reservations {ex.Message}");
   }
}


public Task<Reservation> GetByIdAsync(int id)
{
   try
   {
       var result = _reservationRepository.GetByIdAsync(id);
       if (result == null)
       {
           throw new ServiceException("Reservation not found");
       }
       return result;

   }
   catch (System.Exception ex)
   {

       throw new ServiceException($"Error while getting reservation {ex.Message}");
   }

}

public Task<Reservation> CreateAsync(Reservation reservation)
{
   if (reservation == null)
   {
       throw new ServiceException("Reservation cannot be null");
   }

   try
   {
       var result = _reservationRepository.CreateAsync(reservation);
       if (result == null)
       {
           throw new ServiceException("Reservation not created");
       }
       return result;
   }
   catch (System.Exception ex)
   {

       throw new ServiceException($"Error while creating reservation {ex.Message}");
   }
}

public Task<Reservation> UpdateAsync(Reservation reservation)
{
   if (reservation == null)
   {
       throw new ServiceException("Reservation cannot be null");
   }
   try
   {
       _reservationRepository.UpdateAsync(reservation);
       return Task.FromResult(reservation);
   }
   catch (System.Exception ex)
   {

       throw new ServiceException($"Error while updating reservation {ex.Message}");
   }
}

public async Task<bool> DeleteAsync(int reservationId)
{
   try
   {
     var result = await _reservationRepository.DeleteAsync(reservationId);
     if (result == null)
     {
         throw new ServiceException("Reservation not found");
     }

     return await Task.FromResult(result);
   }
   catch (System.Exception ex)
   {
       throw new ServiceException($"Error while deleting reservation {ex.Message}");

   }
}
}