using GuestExperience.Data;
using GuestExperience.Exception;
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
    public async Task<Reservation> CreateAsync(Reservation reservation)
    {
        if (reservation == null)
        {
            throw new RepositoryException("Reservation cannot incomplete or empty");
        }
        try
        {
            

            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }
        catch
        {
            throw new RepositoryException("Error while creating reservation");
        }
    }

    public async Task<Reservation> GetByIdAsync(int id)
    {
       
        try
        {
          
            var result = await _context.Reservations.FindAsync(id);
            if (result == null)
            {
                throw new RepositoryException("Rservation not found");
                
            }

            return result;
        }
        
        catch (System.Exception ex)
        {
            throw new RepositoryException($"Error while getting reservation {ex.Message}");
        }
    }

    public async Task<IEnumerable<Reservation>> GetAllAsync()
    {
        try
        {
            var result = await _context.Reservations.ToListAsync();
            if (result == null)
            {
                throw new RepositoryException("Reservations not found");
            }
            return result;
        }
        catch (System.Exception ex)
        {
            throw new RepositoryException($"Error while getting reservations {ex.Message}");
    
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var toBeRemoved = await _context.Reservations.FindAsync(id);
            if (toBeRemoved == null)
            {
                throw new RepositoryException($"Reservation with id {id} was not found");
            }
            _context.Reservations.Remove(toBeRemoved);
            await _context.SaveChangesAsync();
            return false;
        }
        catch 
        {
          throw new RepositoryException("Error while deleting reservation");
        }
    }

    public async Task<Reservation> UpdateAsync(Reservation reservation)
    {
        if (reservation == null)
        {
            throw new RepositoryException($"Reservation cannot incomplete or empty");
        }
        try
        {
         
            //_context.Entry(reservation).State = EntityState.Modified;
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }
        catch 
        {
          throw new RepositoryException("Error while updating reservation");
        }
    }
}