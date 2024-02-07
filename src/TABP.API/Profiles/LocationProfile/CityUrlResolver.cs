using AutoMapper;
using TABP.API.DTOs.LocationDtos;
using TABP.Domain.Entities;

namespace TABP.API.Profiles
{
    public class CityUrlResolver : IValueResolver<Location, LocationDto, string>
    {
        public string Resolve(Location source, LocationDto destination, string destMember, ResolutionContext context)
        {
            return $"/api/hotel/location/city/{source.CityId}";
        }
    }
}
