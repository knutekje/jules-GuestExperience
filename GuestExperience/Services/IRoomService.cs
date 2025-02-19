using GuestExperience.Models;

namespace GuestExperience.Services
{
    public interface IRoomService : IService<Room>
    {
        public Task<List<Room>> GetRoomsByFloor(int floor);
        public Task<List<Room>> GetRoomsByRoomType(RoomType roomType);
        public Task<List<Room>> GetRoomsByRoomStatus(RoomStatus roomType);
    }
}