using AutoMapper;
using TABP.API.DTOs.LocationDtos;
using TABP.Domain.Entities;

namespace TABP.API.Profiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile() 
        {
            CreateMap<Location, LocationDto>()
              .ForMember(dest => dest.Links, opt => opt.MapFrom<LocationUrlResolver>());
        }
    }
}
