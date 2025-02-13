using GuestExperience.Models;
using Microsoft.AspNetCore.Mvc;

namespace GuestExperience.Repositories;

public interface IReservationRepository
{
    public Task<Reservation> CreateReservationAsync(Reservation reservation);
    public Task<Reservation> GetReservationAsync(int id);
    public Task<List<Reservation>> GetAllReservationsAsync();
    public Task<Reservation> DeleteReservationAsync(int id);
    public Task<Reservation> UpdateReservationAsync(Reservation reservation);
    
}