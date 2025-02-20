using AutoMapper;
using GuestExperience.DTOs;
using GuestExperience.Exception;
using GuestExperience.Models;
using GuestExperience.Repositories;
using GuestExperience.Services;
using Microsoft.AspNetCore.Mvc;

namespace GuestExperience.Controllers;

[Controller]
[Route("[controller]")]
public class ReservationController : ControllerBase
{
    private readonly IReservationService _reservationService;
    private readonly IMapper _mapper;

    public ReservationController(IReservationService reservationService, IMapper mapper)
    {
        _mapper = mapper;
        _reservationService = reservationService;
    }
        
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
    {

        try
        {
            var result = await _reservationService.GetAllAsync();
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        catch (System.Exception ex)
        {
            throw new ControllerException($"Failed {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Reservation>> GetReservation(int id)
    {
        try
        {
            var result = await _reservationService.GetByIdAsync(id);
            if (result == null)
            {
                throw new ControllerException($"Reservation with id {id} not found");
            }
            return Ok(result);

        }
        catch (System.Exception ex)
        {
            throw new ControllerException($"Failed {ex.Message}");
            
        }
    }

    [HttpPost]
    public async Task<ActionResult<Reservation>> PostReservation([FromBody]  ReservationDTO reservationDto)
    {
        try
        {
            var reservation = _mapper.Map<Reservation>(reservationDto);
            var result = await _reservationService.CreateAsync(reservation);
            if (result == null)
            {
                throw new ControllerException($"Unable to create reservation");
            }
            var createdReservation = _mapper.Map<ReservationDTO>(result);

            
            return Ok(createdReservation);
        }
        catch (System.Exception ex)
        {
            
            throw new ControllerException($"Failed {ex.Message}");
        }
    }

    [HttpPut]
    public async Task<ActionResult<Reservation>> UpdateReservation(Reservation reservation)
    {
        try
        {
            var result = await _reservationService.UpdateAsync(reservation);
            if (result == null)
            {
                throw new ControllerException($"Reservation with id {reservation.Id} not found");
            }
            return Ok(result);
        }
        catch (System.Exception ex)
        {
            
            throw new ControllerException($"Failed {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Reservation>> DeleteReservation(int id)
    {
        try
        {
            var result = await _reservationService.DeleteAsync(id);
            if (result == null)
            {
                throw new ControllerException($"Reservation with id {id} not found");
            }
            return Ok(result);
        }
        catch (System.Exception ex)
        {
            
            throw new ControllerException($"Failed {ex.Message}");
        }
    }
    
}