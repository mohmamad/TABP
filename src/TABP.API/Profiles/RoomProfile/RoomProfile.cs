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
                .ForMember(dest => dest.BookingURL, opt => opt.MapFrom<BookingURLResolver>())
                .ForMember(dest => dest.HotelURL, opt => opt.MapFrom<HotelURLResolver>())
                .ForMember(dest => dest.RoomTypeURL, opt => opt.MapFrom<RoomTypeURLResolver>());
            CreateMap<RoomType, RoomTypeDto>();
            CreateMap<Room, UpdateRoomDto>();
            CreateMap<UpdateRoomDto, Room>();
            CreateMap<Room, FeaturedDealRoomDto>();
        }
    }
}
