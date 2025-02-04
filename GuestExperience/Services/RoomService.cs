using GuestExperience.Models;
using GuestExperience.Repositories;

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
        return await _roomRepository.AddRoomAsync(room);
    }

    public async Task<Room> UpdateRoomAsync(Room room)
    {
        return await _roomRepository.UpdateRoomAsync(room);
    }

    public async Task<Room> DeleteRoom(Room room)
    {
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
        return await _roomRepository.GetRoomAsync(id);
    }

    public async Task<List<Room>> GetRoomsByFloor(int floor)
    {
        return await _roomRepository.GetRoomsByFloor(floor);
    }




    public async Task<List<Room?>> GetRoomsByRoomType(RoomType roomType)
    {
        
        return await _roomRepository.GetRoomsByRoomType(roomType);
        
    }

    public async Task<List<Room?>> GetRoomsByStatus(RoomStatus status)
    {
        return await _roomRepository.GetRoomsByStatus(status);
    }
}