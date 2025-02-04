using GuestExperience.Models;
using GuestExperience.Services;
using Microsoft.AspNetCore.Mvc;

namespace GuestExperience.Controllers;


[ApiController]
[Route("[controller]")]
public class RoomController
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
    
}