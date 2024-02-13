﻿using AutoMapper;
using TABP.API.DTOs.HotelDtos;
using TABP.API.Profiles.FoundHotelUrlResolver;
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
                .ForMember(dest => dest.HotelTypeURL, opt => opt.MapFrom<HotelTypeResolver>())
                .ForMember(dest => dest.AddHotelImageURL, opt => opt.MapFrom<AddHotelImageURLResolver>())
                .ForMember(dest => dest.HotelImageURL, opt => opt.MapFrom<HotelImageURLResolver>());

            CreateMap<Hotel, FoundHotelDto>()
                .ForMember(dest => dest.RoomsURL, opt => opt.MapFrom<FoundRoomURLResolver>())
                .ForMember(dest => dest.HotelLocationURL, opt => opt.MapFrom<FoundHotelLocationURLResolver>())
                .ForMember(dest => dest.HotelTypeURL, opt => opt.MapFrom<FoundHotelTypeResolver>())
                .ForMember(dest => dest.HotelImageURL, opt => opt.MapFrom<FoundHotelImageURLResolver>());

            CreateMap<Hotel, UpdateHotelDto>();
            CreateMap<UpdateHotelDto, Hotel>();
            CreateMap<HotelType, HotelTypeDto>();
            CreateMap<HotelImage, HotelImageDto>();
        }
    }
}
