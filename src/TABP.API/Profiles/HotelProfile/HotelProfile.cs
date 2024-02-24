using AutoMapper;
using TABP.API.DTOs.FeaturedDealsDtos;
using TABP.API.DTOs.HotelDtos;
using TABP.API.Profiles.FeaturedDealsProfile;
using TABP.Domain.Entities;

namespace TABP.API.Profiles
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            CreateMap<Hotel, HotelDto>()
                .ForMember(dest => dest.Links, opt => opt.MapFrom<HotelURLResolver>());

            CreateMap<Hotel, UpdateHotelDto>();
            CreateMap<UpdateHotelDto, Hotel>();
            CreateMap<HotelType, HotelTypeDto>();
            CreateMap<HotelImage, HotelImageDto>();
            CreateMap<Hotel, FeaturedDealHotelDto>()
               .ForMember(dest => dest.Links, opt => opt.MapFrom<FeaturedDealRoomURLResolver>());
        }
    }
}
