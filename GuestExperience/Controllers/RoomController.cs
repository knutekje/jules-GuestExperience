using System.Net;
using GuestExperience.Exception;
using GuestExperience.Models;
using GuestExperience.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GuestExperience.Controllers;


[ApiController]
[Route("[controller]")]
public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService;

    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    [HttpGet]
    public async Task<IEnumerable<Room>> GetRooms()
    {
        return await _roomService.GetRooms();
    }

    [HttpPost]
    public async Task<IActionResult> CreateRoom([FromBody] Room room)
    {
        if (room == null)
        {
            return BadRequest("Room data is required.");
        }
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var createdRoom = await _roomService.CreateRoomAsync(room);

            if (createdRoom == null)
            {
                return StatusCode(500, "Room creation failed due to an unknown error.");
            }

            return CreatedAtAction(nameof(GetRoomById), new { id = createdRoom.Id }, createdRoom);
        }
        catch (RoomValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (RoomCreateFailedException ex)
        {
            return Conflict(ex.Message);
        }
        catch (System.Exception)
        {
            return StatusCode(500, "An error occurred while creating the room.");
        }
    }

 
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoomById(int id)
    {
        var room = await _roomService.GetRoomById(id);
        if (room == null)
        {
            return NotFound();
        }
        return Ok(room);
    }
    
}