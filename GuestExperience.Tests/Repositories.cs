using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using GuestExperience.Data;
using GuestExperience.Models;
using GuestExperience.Repositories;

namespace GuestExperience.Tests.Repositories
{
    public class RoomRepositoryTests
    {
        
        private GuestExperienceDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<GuestExperienceDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new GuestExperienceDbContext(options);
        }

        [Fact]
        public async Task AddRoomAsync_AddsRoomSuccessfully()
        {
            using var context = GetInMemoryDbContext();
            var repository = new RoomRepository(context);
            
            var room = new Room
            {
                RoomNumber = 101,
                Capacity = 2,
                Floor = 1,
                RoomType = RoomType.Standard,   
                Status = RoomStatus.Clean,   
                
            };

            var addedRoom = await repository.AddRoomAsync(room);

            Assert.NotNull(addedRoom);
            Assert.NotEqual(0, addedRoom.Id); 
            Assert.Equal(101, addedRoom.RoomNumber);

            var retrievedRoom = await repository.GetRoomAsync(addedRoom.Id);
            Assert.NotNull(retrievedRoom);
            Assert.Equal(101, retrievedRoom.RoomNumber);
            Assert.Equal(2, retrievedRoom.Capacity);
        }
    }
}
