using GuestExperience.Exception;
using GuestExperience.Models;
using GuestExperience.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace GuestExperience.Services;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;
    public RoomService(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }
    public async Task<Room> CreateRoomAsync(Room room)
    {
        var existingRooms = await _roomRepository.GetAllRoomsAsync();
        if (existingRooms.Any(r => r.RoomNumber == room.RoomNumber))
        {
            throw new RoomCreateFailedException("A room with this number already exists.");
        }

        return await _roomRepository.AddRoomAsync(room);
    }

    
    
    

    public async Task<Room> UpdateRoomAsync(Room room)
    {
        ArgumentNullException.ThrowIfNull(room);
        return await _roomRepository.UpdateRoomAsync(room);
    }

    public async Task<Room> DeleteRoom(Room room)
    {
        ArgumentNullException.ThrowIfNull(room);
        return await _roomRepository.DeleteRoomAsync(room);
        
    }

    public async Task<List<Room>> GetRooms()
    {
        if (_roomRepository == null)
        {
            throw new NullReferenceException("RoomRepository is null");
        }
        return await _roomRepository.GetAllRoomsAsync();
        
    }

    public async Task<Room> GetRoomById(int id)
    {
        try
        {
            return await _roomRepository.GetRoomByIdAsync(id);
        }
        catch (System.Exception ex)
        {
            throw new RoomNotFoundException($"Room with id {id} was not found.", ex);
        }
    }


    public async Task<List<Room>> GetRoomsByFloor(int floor)
    {
        if(_roomRepository == null)
        {
            throw new NullReferenceException("RoomRepository is null");
        };
        return await _roomRepository.GetRoomsByFloor(floor);
    }




    public async Task<List<Room>> GetRoomsByRoomType(RoomType roomType)
    {
        return await _roomRepository.GetRoomsByRoomType(roomType);
        
    }

    public async Task<List<Room>> GetRoomsByStatus(RoomStatus status)
    {
        return await _roomRepository.GetRoomsByStatus(status);
    }
}