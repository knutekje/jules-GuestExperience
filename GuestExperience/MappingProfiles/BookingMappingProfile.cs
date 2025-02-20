using AutoMapper;
using GuestExperience.DTOs;
using GuestExperience.Models;

namespace GuestExperience.MappingProfiles;

public class BookingMappingProfile : Profile
{
    public BookingMappingProfile()
    {
        CreateMap<Booking, BookingDTO>();
        CreateMap<BookingDTO, Booking>();
    }
}