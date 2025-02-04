using GuestExperience.Data;
using GuestExperience.Models;
using GuestExperience.Repositories;
using GuestExperience.Services;
using Moq;

namespace GuestExperienceTests.Services;

public class RoomServiceTest
{
    private readonly Mock<IRoomRepository> _mockRoomRepository;
    private readonly RoomService _roomService;
    
    private readonly List<Room> _rooms = new List<Room>();
    
    public RoomServiceTest()
    {
        _mockRoomRepository = new Mock<IRoomRepository>();

        _mockRoomRepository
            .Setup(repo => repo.AddRoomAsync(It.IsAny<Room>()))
            .ReturnsAsync((Room room) =>
            {
                room.Id = _rooms.Count + 1;
                _rooms.Add(room);
                return room;
            });

        _mockRoomRepository
            .Setup(repo => repo.GetAllRoomsAsync())
            .ReturnsAsync(() => _rooms);

        _roomService = new RoomService(_mockRoomRepository.Object);
    }
    
    
    
        
    [Fact]
    public async Task GetAllRooms_ReturnsAllRooms()
    {
        await _roomService.CreateRoomAsync(new Room
        {
            //Id = 0,
            RoomNumber = 102,
            RoomType = RoomType.Standard,
            Capacity = 0,
            Status = RoomStatus.Clean,
            PriceId = 0,
            Floor = 0,
            ExtraBed = false,
            LastMaintained = null,
            CreatedAt = null,
            UpdatedAt = null
        });
        await _roomService.CreateRoomAsync(new Room
        {
            //Id = 0,
            RoomNumber = 132,
            RoomType = RoomType.Standard,
            Capacity = 0,
            Status = RoomStatus.Clean,
            PriceId = 0,
            Floor = 0,
            ExtraBed = false,
            LastMaintained = null,
            CreatedAt = null,
            UpdatedAt = null
        });
        
        
        var rooms = await _roomService.GetRooms();
        
        
        
        Assert.Equal(2, rooms.Count);
       
        

    }
}