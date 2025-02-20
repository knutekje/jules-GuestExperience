using AutoMapper;
using GuestExperience.Models;
using GuestExperience.DTOs;

namespace GuestExperience.MappingProfiles
{
    public class RoomMappingProfile : Profile
    {
        public RoomMappingProfile()
        {
            CreateMap<Room, RoomDTO>();



            CreateMap<RoomDTO, Room>();


        }

     
    }
}