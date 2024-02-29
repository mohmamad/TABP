using AutoMapper;
using TABP.API.DTOs.AmenityDtos;
using TABP.Domain.Entities;

namespace TABP.API.Profiles.AmenityProfiles
{
    public class AmenityProfile : Profile
    {
        public AmenityProfile()
        {
            CreateMap<Amenity, AmenityDto>();
        }
    }
}
