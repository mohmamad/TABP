using AutoMapper;
using TABP.API.DTOs.RoomDtos;
using TABP.Domain.Entities;

namespace TABP.API.Profiles.RoomProfile
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomDto>()
                .ForMember(dest => dest.Links, opt => opt.MapFrom<RoomURLResolver>());

            CreateMap<RoomType, RoomTypeDto>();
            CreateMap<Room, UpdateRoomDto>();
            CreateMap<UpdateRoomDto, Room>();
            CreateMap<Room, FeaturedDealRoomDto>();
        }
    }
}
