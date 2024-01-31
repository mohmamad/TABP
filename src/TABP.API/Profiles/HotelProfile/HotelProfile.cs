using AutoMapper;
using TABP.API.DTOs;
using TABP.Domain.Entities;

namespace TABP.API.Profiles
{
    public class HotelProfile : Profile
    {
        public HotelProfile() 
        {
            CreateMap<Hotel, HotelDto>()
                .ForMember(dest => dest.AddLocationURL, opt => opt.MapFrom<AddHotelLocationURLResolver>())
                .ForMember(dest => dest.RoomsURL, opt => opt.MapFrom<RoomURLResolver>())
                .ForMember(dest => dest.HotelLocationURL, opt => opt.MapFrom<HotelLocationURLResolver>())
                .ForMember(dest => dest.HotelTypeURL, opt => opt.MapFrom<HotelTypeResolver>());

            CreateMap<Hotel, UpdateHotelDto>();
            CreateMap<UpdateHotelDto, Hotel>();
        }
    }
}
