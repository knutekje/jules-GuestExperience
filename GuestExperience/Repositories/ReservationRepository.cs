using GuestExperience.Data;
using GuestExperience.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuestExperience.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly GuestExperienceDbContext _context;

    public ReservationRepository(GuestExperienceDbContext context)
    {
        _context = context;
    }
    public async Task<Reservation> CreateReservationAsync(Reservation reservation)
    {
        try
        {
            if (reservation == null)
            {
                throw new ArgumentNullException(nameof(reservation));
            }

            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }
        catch
        {
            throw new AbandonedMutexException();
        }
    }

    public async Task<Reservation> GetReservationAsync(int id)
    {
        try
        {
            if (id <= 0)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return await _context.Reservations.FindAsync(id);
        }
        
        catch
        {
            throw new AbandonedMutexException();
        }
    }

    public async Task<List<Reservation>> GetAllReservationsAsync()
    {
        try
        {
            return await _context.Reservations.ToListAsync();
        }
        catch
        {
            throw new AbandonedMutexException();
        }
    }

    public async Task<Reservation> DeleteReservationAsync(int id)
    {
        try
        {
            Reservation toBeRemoved = await _context.Reservations.FindAsync(id);
            if (toBeRemoved == null)
            {
                throw new InvalidOperationException($"Reservation with id {id} was not found");
            }
            _context.Reservations.Remove(toBeRemoved);
            await _context.SaveChangesAsync();
            return toBeRemoved;
        }
        catch 
        {
          throw new AbandonedMutexException();
        }
    }

    public async Task<Reservation> UpdateReservationAsync(Reservation reservation)
    {
        try
        {
            if (reservation == null)
            {
                throw new ArgumentNullException(nameof(reservation));
            }
            _context.Entry(reservation).State = EntityState.Modified;
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }
        catch 
        {
          throw new AbandonedMutexException();
        }
    }
}