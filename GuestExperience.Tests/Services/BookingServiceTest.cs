using GuestExperience.Models;
using GuestExperience.Repositories;
using Moq;
using NSubstitute;

namespace GuestExperienceTests.Services;

public class BookingServiceTest
{
    private readonly IBookingService _bookingService;
    private readonly IBookingRepository _bookingRepository;

    private List<Booking> testBookings; 
    
    
    
    public BookingServiceTest()
    {
        _bookingRepository = Substitute.For<IBookingRepository>();
        
        testBookings = new List<Booking>
        {
            new Booking
            {
                Id = 2,
                CheckIn = DateTime.Today,
                CheckOut = DateTime.Today.AddDays(3),
          
                RoomId = 2,
                Room = new Room
                {
                    Id = 1,
                    RoomNumber = 2,
                    RoomType = RoomType.Standard,
                    Floor = 2,
                    Capacity = 2,
                    Status = RoomStatus.Clean
                }
                
            },
            new Booking
            {
                Id = 1,
                CheckIn = DateTime.Now,
                CheckOut = DateTime.Now.AddDays(7),
            
                RoomId = 1,
                Room = new Room
                {
                    Id = 1,
                    RoomNumber = 1,
                    RoomType = RoomType.Double,
                    Capacity = 1,
                    Floor = 2,


                },
             
                
                


            }
        };
        _bookingRepository.GetAllBookingsAsync().Returns((testBookings));
        _bookingRepository
            .DeleteBookingAsync(Arg.Any<int>())
            .Returns(callInfo =>
            {
                var bookingId = callInfo.Arg<int>();
                var bookingToDelete = testBookings.FirstOrDefault(b => b.Id == bookingId);
                if (bookingToDelete != null)
                {
                    testBookings.Remove(bookingToDelete);
                    return true;
                }
                return false;
            });

        _bookingService = new BookingService(_bookingRepository);
        _bookingRepository
            .GetBookingByIdAsync(Arg.Any<int>())!
            .Returns(
                callInfo =>
                {
                    var passedId = callInfo.Arg<int>();
                    return testBookings.FirstOrDefault(x => x.Id == passedId);
                });
        _bookingRepository
            .CreateBookingAsync(Arg.Any<Booking>())
            .Returns(callInfo =>
            {
                var booking = callInfo.Arg<Booking>();
                booking.Id = 1; 
                return Task.FromResult(booking);
            });
    }

    [Fact]
    public async Task Create_Booking_AssignsNewId()
    {
        Booking bookingToCreate = new Booking
        {
            Id = 0, 
            CheckIn = DateTime.UtcNow,
            CheckOut = DateTime.UtcNow.AddDays(1),
            RoomId = 1,
            Room = null 
        };

        Booking result = await _bookingService.CreateBookingAsync(bookingToCreate);

        Assert.NotEqual(0, result.Id);
    }

    
    [Fact]
    public async Task Update_Booking()
    {
        Booking bookingToCreate = new Booking
        {
            Id = 2,
            CheckIn = default,
            CheckOut = default,
           
           
            RoomId = 0,
            Room = null
        };
        await _bookingService.CreateBookingAsync(bookingToCreate);
        Booking bookingToUpdate = new Booking
        {
            Id = 2,
            CheckIn = default,
            CheckOut = default,
      
      
            RoomId = 0,
            Room = null
        };
        
        var result = _bookingService.UpdateBookingAsync(bookingToUpdate);
      
    }
    [Fact]
    public async Task Delete_Booking(){
       
         _bookingService.DeleteBookingAsync(testBookings[0].Id);
        var result = await _bookingService.GetAllBookingsAsync(); 
        Assert.Single(result);
        
    }
    [Fact]
    public async Task Get_Booking()
    {
        int passedId = 2;
        Booking returnedBooking = await _bookingService.GetBookingById(passedId);        
        Assert.Equal(passedId, returnedBooking.Id);
    }
    [Fact]
    public async Task Get_Bookings()
    {
        var result = await _bookingService.GetAllBookingsAsync();
        Assert.Equal(2, result.Count());
    }

    
}
