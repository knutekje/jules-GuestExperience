using GuestExperience.Models;

namespace GuestExperience.Services;

public interface IRoomService
{
    public Task<Room> CreateRoomAsync(Room room);
    public Task<Room> UpdateRoomAsync(Room room);
    public Task<Room?> DeleteRoom(Room room);
    public Task<List<Room>> GetRooms();
    public Task<Room> GetRoomById(int id);
    public Task<List<Room>> GetRoomsByFloor(int floor);
    public Task<List<Room>> GetRoomsByRoomType(RoomType roomType);
    public Task<List<Room>> GetRoomsByStatus(RoomStatus status);
    
}