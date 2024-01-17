using AutoMapper;
using TABP.API.DTOs;
using TABP.Domain.Entities;

namespace TABP.API.Profiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile() 
        {
            CreateMap<Location, LocationDto>()
              .ForMember(dest => dest.CityURL, opt => opt.MapFrom<CityUrlResolver>());
        }
    }
}
