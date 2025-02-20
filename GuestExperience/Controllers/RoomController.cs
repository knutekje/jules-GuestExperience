using System.Net;
using AutoMapper;
using GuestExperience.DTOs;
using GuestExperience.Exception;
using GuestExperience.Models;
using GuestExperience.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace GuestExperience.Controllers;


[ApiController]
[Route("[controller]")]
public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService;
    private readonly IMapper _mapper;

    public RoomController(IRoomService roomService, IMapper mapper)
    {
        _mapper = mapper;
        _roomService = roomService;
    }

    [HttpGet]
    public async Task<IEnumerable<Room>> GetRooms()
    {
        try
        {
            return await _roomService.GetAllAsync();
        }
        catch (System.Exception ex)
        {
            throw new  ControllerException($"Failed to retrieve all rooms {ex}");
        }
        
    }

    [HttpPost]
    public async Task<IActionResult> CreateRoom([FromBody] RoomDTO roomDto)
    {
   
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var room = _mapper.Map<Room>(roomDto);
            var createdRoom = await _roomService.CreateAsync(room);

            var createdRoomDto = _mapper.Map<RoomDTO>(createdRoom);
            return CreatedAtAction(nameof(GetRoomById), new { id = createdRoom.Id }, createdRoomDto);
        }
        catch (RoomValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (RoomCreateFailedException ex)
        {
            return Conflict(ex.Message);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, "An error occurred while creating the room." + ex.Message);
        }
    }

 
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoomById(int id)
    {
        var room = await _roomService.GetByIdAsync(id);
        if (room == null)
        {
            return NotFound();
        }
        return Ok(room);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRoom(int id, [FromBody] Room room)
    {
        try
        {
            await _roomService.UpdateAsync(room);
            return NoContent();
        }
        catch (System.Exception ex)
        {
            throw new  ControllerException($"Failed to update room {ex}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoom(int id)
    {
        try
        {
            var result =  await _roomService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok(new {message = "Room deleted successfully"});
        }
        catch (System.Exception ex)
        {
            
            throw new  ControllerException($"Failed to delete room {ex}");
        }
    }

    [HttpGet("status/{status}")]
    public async Task<IActionResult> GetRoomStatus(RoomStatus roomstatus)
    {
        try
        {
            var result = await _roomService.GetRoomsByRoomStatus(roomstatus);
            if (result == null)
            {
                throw new ControllerException($"No room with status {roomstatus} found");
            }
            return Ok(result);
        }
        catch (System.Exception ex)
        {
            throw new  ControllerException($"Failed to get room status {ex}");
            
        }
    }

    [HttpGet("floor/{floor}")]
    public async Task<IActionResult> GetRoomByFloor(int floor)
    {
        try
        {
            var result = await _roomService.GetRoomsByFloor(floor);
            if (result == null)
            {
                throw new ControllerException($"No room with floor {floor} found");
            }
            return Ok(result);
        }
        catch (System.Exception ex)
        {
            
            throw new  ControllerException($"Failed to get room by floor {floor}");
        }
    }

    [HttpGet("type/{roomType}")]
    public async Task<IActionResult> GetRoomsByRoomType(RoomType roomType)
    {
        try
        {
            var result = await _roomService.GetRoomsByRoomType(roomType);
            if (result == null)
            {
                throw new ControllerException($"No rooms with room type {roomType} found");
            }
            return Ok(result);
        }
        catch (System.Exception ex)
        {
            
            throw new ControllerException($"Error while fetching room");
        }
    }
    
}