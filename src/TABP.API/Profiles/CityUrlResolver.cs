using AutoMapper;
using TABP.API.DTOs;
using TABP.Domain.Entities;

namespace TABP.API.Profiles
{
    public class CityUrlResolver : IValueResolver<Location, LocationDto, string>
    {
        public string Resolve(Location source, LocationDto destination, string destMember, ResolutionContext context)
        {
            return $"https://localhost:7183/api/location/city/{source.CityId}";
        }
    }
}
