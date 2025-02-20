using AutoMapper;
using GuestExperience.DTOs;
using GuestExperience.Models;

namespace GuestExperience.MappingProfiles;

public class GuestMappingProfile : Profile
{
    public GuestMappingProfile()
    {
        CreateMap<GuestDTO, Guest>();

        CreateMap<Guest, GuestDTO>();
    }
}