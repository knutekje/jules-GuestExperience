/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuestExperience.Models;
using GuestExperience.Repositories;
using GuestExperience.Services;
using NSubstitute;
using Xunit;
using Xunit.Abstractions;

namespace GuestExperienceTests.Services
{
    public class RoomServiceTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly IRoomRepository _roomRepository;
        private readonly RoomService _roomService;
        private readonly List<Room> _rooms;

        public RoomServiceTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _roomRepository = Substitute.For<IRoomRepository>();

            // Prepopulate the list with four rooms.
            _rooms = new List<Room>
            {
                new Room 
                { 
                    Id = 1, 
                    RoomNumber = 101, 
                    RoomType = RoomType.Standard, 
                    Capacity = 2, 
                    Status = RoomStatus.Clean, 
                    PriceId = 100, 
                    Floor = 1, 
                    ExtraBed = false, 
                    LastMaintained = DateTime.UtcNow, 
                    CreatedAt = DateTime.UtcNow, 
                    UpdatedAt = DateTime.UtcNow 
                },
                new Room 
                { 
                    Id = 2, 
                    RoomNumber = 102, 
                    RoomType = RoomType.Double, 
                    Capacity = 2, 
                    Status = RoomStatus.Dirty, 
                    PriceId = 150, 
                    Floor = 1, 
                    ExtraBed = false, 
                    LastMaintained = DateTime.UtcNow, 
                    CreatedAt = DateTime.UtcNow, 
                    UpdatedAt = DateTime.UtcNow 
                },
                new Room 
                { 
                    Id = 3, 
                    RoomNumber = 103, 
                    RoomType = RoomType.Standard, 
                    Capacity = 2, 
                    Status = RoomStatus.Clean, 
                    PriceId = 100, 
                    Floor = 1, 
                    ExtraBed = true, 
                    LastMaintained = DateTime.UtcNow, 
                    CreatedAt = DateTime.UtcNow, 
                    UpdatedAt = DateTime.UtcNow 
                },
                new Room 
                { 
                    Id = 4, 
                    RoomNumber = 104, 
                    RoomType = RoomType.Suite, 
                    Capacity = 4, 
                    Status = RoomStatus.OutOfService, 
                    PriceId = 300, 
                    Floor = 2, 
                    ExtraBed = false, 
                    LastMaintained = DateTime.UtcNow, 
                    CreatedAt = DateTime.UtcNow, 
                    UpdatedAt = DateTime.UtcNow 
                }
            };

            _roomRepository.GetAllAsync().Returns(Task.FromResult(_rooms));

            _roomRepository
                .GetRoomsByRoomStatus(Arg.Any<RoomStatus>())
                .Returns(callInfo =>
                {
                    var status = callInfo.Arg<RoomStatus>();
                    return Task.FromResult(_rooms.Where(r => r.Status == status).ToList());
                });

            _roomService = new RoomService(_roomRepository);
        }

        [Fact]
        public async Task GetAllRooms_ReturnsAllRooms()
        {
            var result = await _roomService.GetAllAsync();

            Assert.Equal(4, result.Count);
        }

        [Fact]
        public async Task GetAllRoomsByStatus_ReturnsAllRoomsByStatus()
        {
            // Act: Request rooms with status 'Clean'. (From our test data, rooms with Ids 1 and 3 are Clean.)
            var result = await _roomService.GetRoomsByStatus(RoomStatus.Clean);

            // Assert: Verify that exactly 2 rooms are returned.
            Assert.Equal(2, result.Count);
        }
    }
}
*/
