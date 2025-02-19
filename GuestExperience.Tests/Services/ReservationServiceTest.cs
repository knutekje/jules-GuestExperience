/*using System.Dynamic;
using GuestExperience.Models;
using GuestExperience.Repositories;
using GuestExperience.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using NSubstitute;
using Xunit.Abstractions;

namespace GuestExperienceTests.Services;

public class ReservationServiceTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly IReservationRepository _reservationRepository;
    private readonly ReservationService _reservationService;
    private List<Reservation> _testReservations;
    
    public ReservationServiceTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _reservationRepository = Substitute.For<IReservationRepository>();
        _reservationService = new ReservationService(_reservationRepository);
        
        _testReservations = [new Reservation
        {
            Id = 2,
            GuestId = 0,
            Guest = null,
            Bookings = null
        }, new Reservation
        {
            Id = 1,
            GuestId = 0,
            Guest = null,
            Bookings = null
        }
        ];
        _reservationRepository.CreateAsync(Arg.Any<Reservation>())
            .Returns(callInfo =>
            {
                var reservation = callInfo.Arg<Booking>();
                reservation.Id = 1; 
                return Task.FromResult(reservation);
            });
        
    }

    [Fact]
    public async Task CreateReservationAsync_CreatesReservation()
    {
       
        
        Reservation resevationToCreate = new Reservation
        {
            Id = 4,
            GuestId = 4,
            Guest = null,
            Bookings = null
        };
        var result = await _reservationService.CreateAsync(resevationToCreate);
        Assert.NotNull(result);
        Assert.IsType<Reservation>(result);
        Assert.Equal(resevationToCreate.GuestId, result.GuestId);
    } 
        
        
    [Fact]
    public async Task GetAllReservations_ShouldReturnAllReservations()
    {
        _reservationRepository.GetAllAsync()
            .Returns(Task.FromResult(new List<Reservation>([new Reservation
                {
                    Id = 0,
                    GuestId = 0,
                    Guest = null,
                    Bookings = null
                },
                new Reservation
                {
                    Id = 0,
                    GuestId = 0,
                    Guest = null,
                    Bookings = null
                }
            ])));
        var result = await _reservationRepository.GetAllAsync();
        
        Assert.NotNull(result);
        //Assert.Equal(2, result.Count);
        Assert.NotEmpty(result);

    }

    [Fact]
    public async Task DeleteReservationAsync()
    {


            
    }
    
        
    
}*/