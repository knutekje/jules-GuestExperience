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
        if (room == null)
        {
            throw new ServiceException("Missing room data");
        }
        var existingRooms = await _roomRepository.GetAllRoomsAsync();
        if (existingRooms.Any(r => r.RoomNumber == room.RoomNumber))
        {
            throw new ServiceException("A room with this number already exists.");
        }

        return await _roomRepository.AddRoomAsync(room);
    }

    
    
    

    public async Task<Room> UpdateRoomAsync(Room room)
    {
        if (room == null)
        {
            throw new ServiceException("Missing room data");
            
        }
        try
        {
            var succeRoom = await _roomRepository.UpdateRoomAsync(room);
            return succeRoom;
        }
        catch (System.Exception ex)
        {
           throw new ServiceException($"Failed to update room data {ex}");
        }
    }

    public async Task<bool> DeleteRoom(int id)
    {
        if (id == null)
        {
            throw new ServiceException("Missing room data");
        }
        try
        {
            return await _roomRepository.DeleteRoomAsync(id);
        }
        catch (System.Exception ex)
        {
            
            throw new ServiceException($"Failed to delete room data {ex}");
        }
        
    }

    public async Task<List<Room>> GetAllRoomsAsync()
    {
        if (_roomRepository == null)
        {
            throw new ServiceException("No room data");
        }
        return await _roomRepository.GetAllRoomsAsync();
        
    }

    public async Task<Room> GetRoomById(int id)
    {
        if (id == null)
        {
            throw new ServiceException("No Id provided");
        }
        try
        {
            var foundRoom = await _roomRepository.GetRoomByIdAsync(id);
            if (foundRoom == null)
            {
                throw new ServiceException($"Room with id:{id} does not exist");
            }
            return foundRoom;
        }
        catch (System.Exception ex)
        {
            throw new ServiceException($"Room with id {id} was not found {ex.Message}.");
        }
    }


    public async Task<List<Room>> GetRoomsByFloor(int floor)
    {
        if (floor == null)
        {
            throw new RoomNotFoundException("Floor number provided");
        }
        var foundRooms = await _roomRepository.GetRoomsByFloor(floor);
        if (foundRooms == null)
        {
            throw new RoomNotFoundException("No rooms found");
        }
        return foundRooms;
    }




    public async Task<List<Room>> GetRoomsByRoomType(RoomType roomType)
    {
        if (roomType == null)
        {
            throw new RoomNotFoundException("no room type provided");
        }

        try
        {
            var foundRooms = await _roomRepository.GetRoomsByRoomType(roomType);
            if (foundRooms == null)
            {
                throw new RoomNotFoundException("No rooms found");
            }

            return foundRooms;
        }
        catch (System.Exception e)
        {
            throw new RoomNotFoundException($"Room with room type {roomType} was not found.", e);
        }
    }

    public async Task<List<Room>> GetRoomsByStatus(RoomStatus status)
    {
        if (status == null)
        {
            throw new RoomNotFoundException("No room status provided");
        }

        try
        {
            var foundRooms = await _roomRepository.GetRoomsByStatus(status);
            if (foundRooms == null)
            {
                throw new RoomNotFoundException("No rooms found");
            }
            return foundRooms;
        }
        catch (System.Exception e)
        {
                
                throw new RoomNotFoundException($"Room with status {status} was not found.", e);
        }
    }
}