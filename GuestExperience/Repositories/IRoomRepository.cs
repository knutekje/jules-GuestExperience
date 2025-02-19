using GuestExperience.Models;

namespace GuestExperience.Repositories;

public interface IRoomRepository: IRepository<Room>
{
    public Task<List<Room>> GetRoomsByFloor(int floor);
    public Task<List<Room>> GetRoomsByRoomType(RoomType roomType);
    public Task<List<Room>> GetRoomsByRoomStatus(RoomStatus roomStatus);
}