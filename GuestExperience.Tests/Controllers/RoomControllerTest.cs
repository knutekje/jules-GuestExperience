using GuestExperience.Controllers;
using GuestExperience.Models;
using GuestExperience.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace GuestExperience.Tests.Repositories.Controllers;

public class RoomControllerTest
{
    private readonly RoomController _roomController;
    private readonly Mock<IRoomService> _roomServiceMock;

    public RoomControllerTest()
    {
        _roomServiceMock = new Mock<IRoomService>();
        _roomController = new RoomController(_roomServiceMock.Object);
    }

    [Fact]
    public async Task CreateNullRoom()
    {
        Room nullRoom = null;
        var result = await _roomController.CreateRoom(nullRoom);
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Room data is required.", badRequestResult.Value);
    }

    [Fact]
    public async Task CreateRoom_Sucessfully()
    {
        Room validRoom = new Room
        {
            RoomNumber = 335,
            RoomType = RoomType.Double,
            Capacity = 2,
            Status = RoomStatus.Clean,
            PriceId = 32,
            Floor = 3,
            ExtraBed = false,
            LastMaintained = null,
            CreatedAt = null,
            UpdatedAt = null
        };
        _roomServiceMock.Setup(s => s.CreateRoomAsync(It.IsAny<Room>())).ReturnsAsync((Room room) => room);
        var result = await _roomController.CreateRoom(validRoom);
        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        var createdRoom = Assert.IsType<Room>(createdResult.Value);
        Assert.Equal(createdRoom.RoomNumber, validRoom.RoomNumber);
        Assert.Equal(0, createdRoom.Id);
    }
    
}