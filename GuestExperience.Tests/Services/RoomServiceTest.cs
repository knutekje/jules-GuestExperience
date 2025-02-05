using GuestExperience.Data;
using GuestExperience.Exception;
using GuestExperience.Models;
using GuestExperience.Repositories;
using GuestExperience.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using SQLitePCL;
using Xunit.Abstractions;

namespace GuestExperienceTests.Services;

public class RoomServiceTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly Mock<IRoomRepository> _mockRoomRepository;
    private readonly RoomService _roomService;
    
    private readonly List<Room> _rooms = [];
    
    public RoomServiceTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
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
        
        _mockRoomRepository.Setup(r => r.GetRoomsByStatus(It.IsAny<RoomStatus>()))
            .ReturnsAsync((RoomStatus status) => _rooms.Where(r => r.Status == status).ToList());
        
        _mockRoomRepository.Setup(r => r.GetRoomsByRoomType(It.IsAny<RoomType>()))
            .ReturnsAsync((RoomType type) => _rooms.Where(r => r.RoomType == type).ToList());
        
        _mockRoomRepository.Setup(r => r.GetRoomByIdAsync(It.IsAny<int>()))!
            .ReturnsAsync((int id)=> _rooms.FirstOrDefault(r => r.Id == id));
        
        _roomService = new RoomService(_mockRoomRepository.Object);
    }


    private async Task populateRooms()
    {
        await _roomService.CreateRoomAsync(new Room
        {
            RoomNumber = 102,
            RoomType = RoomType.Standard,
            Capacity = 0,
            Status = RoomStatus.Dirty,
            PriceId = 0,
            Floor = 0,
            ExtraBed = false,
            LastMaintained = null,
            CreatedAt = null,
            UpdatedAt = null
        });
        
        await _roomService.CreateRoomAsync(new Room
        {
            RoomNumber = 122,
            RoomType = RoomType.Double,
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
            Status = RoomStatus.OutOfService,
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
            RoomNumber = 152,
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
    }
    
    
        
    [Fact]
    public async Task GetAllRooms_ReturnsAllRooms()
    {
        populateRooms();
        
        
        var rooms = await _roomService.GetRooms();
        
        
        
        Assert.Equal(4, rooms.Count);
       
        

    }

    [Fact]
    public async Task GetAllRoomsByStatus_ReturnsAllRoomsByStatus()
    {
        populateRooms();
        
        var rooms = await _roomService.GetRoomsByStatus(RoomStatus.Clean);
        Assert.Equal(2, rooms.Count);
    }


    [Fact]
    public async Task GetRoomsByRoomType_ReturnsRoomsByRoomType()
    {
        await populateRooms();
        var room = await _roomService.GetRoomsByRoomType(RoomType.Standard);
        Assert.Equal(3, room.Count);
    }


    [Fact]
    public async Task GetRoomsByRoomId_ReturnsRoomsByRoomId()
    {
        await populateRooms();
        const int roomId = 152;
        var room = await _roomService.GetRoomById(roomId);
        
    }

    [Fact]
    public async Task GetRoomById_NotFoundById()
    {
        
        _mockRoomRepository
            .Setup(repo => repo.GetRoomByIdAsync(It.IsAny<int>()))
            .ThrowsAsync(new RoomNotFoundException("Room not found"));
        
        await populateRooms();
        await Assert.ThrowsAsync<RoomNotFoundException>(() => _roomService.GetRoomById(123));
        
        
        
    }

    [Fact]
    public async Task CreateRoomAsync_RoomCreated()
    {
        _mockRoomRepository.Setup(r => r.AddRoomAsync(It.IsAny<Room>()))
            .ReturnsAsync((Room room) => room);
        
        var room = await _roomService.CreateRoomAsync(new Room
        {
            Id = 12,
            RoomNumber = 0,
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
        
        Assert.Equal(12, room.Id);
    }

    [Fact]
    public async Task CreateRoomAsync_DuplicateRoom()
    {
        Room room = new Room
        {
            Id = 13,
            RoomNumber = 0,
            RoomType = RoomType.Standard,
            Capacity = 0,
            Status = RoomStatus.Clean,
            PriceId = 0,
            Floor = 0,
            ExtraBed = false,
            LastMaintained = null,
            CreatedAt = null,
            UpdatedAt = null
        };
        await _roomService.CreateRoomAsync(room);
        await Assert.ThrowsAsync<RoomCreateFailedException>(() => _roomService.CreateRoomAsync(room));
        
    }
}