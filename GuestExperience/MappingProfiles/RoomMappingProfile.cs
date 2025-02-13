using AutoMapper;
using GuestExperience.Models;
using GuestExperience.DTOs;

namespace GuestExperience.MappingProfiles
{
    public class RoomMappingProfile : Profile
    {
        public RoomMappingProfile()
        {
            CreateMap<Room, RoomDTO>()
                .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.RoomType.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<RoomDTO, Room>()
                .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.RoomType.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        }
    }
}