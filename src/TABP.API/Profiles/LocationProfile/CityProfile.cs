using AutoMapper;
using TABP.API.DTOs.LocationDtos;
using TABP.Domain.Entities;

namespace TABP.API.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile() 
        {
            CreateMap<City, CityDto>();
        }
        
    }
}
