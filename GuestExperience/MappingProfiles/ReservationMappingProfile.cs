using AutoMapper;
using GuestExperience.DTOs;
using GuestExperience.Models;

namespace GuestExperience.MappingProfiles;

public class ReservationMappingProfile : Profile
{
    public ReservationMappingProfile()
    {
        CreateMap<Reservation, ReservationDTO>();
        CreateMap<ReservationDTO, Reservation>();
    }
}