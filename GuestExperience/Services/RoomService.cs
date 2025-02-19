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
    
    
    public async Task<Room> CreateAsync(Room room)
    {
        if (room == null)
        {
            throw new ServiceException("Missing room data");
        }
        var existingRooms = await _roomRepository.GetAllAsync();
        if (existingRooms.Any(r => r.RoomNumber == room.RoomNumber))
        {
            throw new ServiceException("A room with this number already exists.");
        }

        return await _roomRepository.CreateAsync(room);
    }

    
    
    

    public async Task<Room> UpdateAsync(Room room)
    {
        if (room == null)
        {
            throw new ServiceException("Missing room data");
            
        }
        try
        {
            var succeRoom = await _roomRepository.UpdateAsync(room);
            return succeRoom;
        }
        catch (System.Exception ex)
        {
           throw new ServiceException($"Failed to update room data {ex}");
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var  result = await _roomRepository.DeleteAsync(id);
            if (!result)
            {
                throw new ServiceException($"Failed to delete room data {id}");
            }
            return result;

        }
        catch (System.Exception ex)
        {
            throw new ServiceException($"Failed to delete room data {ex}");
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
            return await _roomRepository.DeleteAsync(id);
        }
        catch (System.Exception ex)
        {
            
            throw new ServiceException($"Failed to delete room data {ex}");
        }
        
    }

    public async Task<IEnumerable<Room>> GetAllAsync()
    {
        if (_roomRepository == null)
        {
            throw new ServiceException("No room data");
        }
        return await _roomRepository.GetAllAsync();
        
    }

    public async Task<Room> GetByIdAsync(int id)
    {
        if (id == null)
        {
            throw new ServiceException("No Id provided");
        }
        try
        {
            var foundRoom = await _roomRepository.GetByIdAsync(id);
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

    public Task<List<Room>> GetRoomsByRoomStatus(RoomStatus roomType)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Room>> GetRoomsByStatus(RoomStatus status)
    {
        if (status == null)
        {
            throw new RoomNotFoundException("No room status provided");
        }

        try
        {
            var foundRooms = await _roomRepository.GetRoomsByRoomStatus(status);
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