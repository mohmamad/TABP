using AutoMapper;
using TABP.API.DTOs;
using TABP.API.DTOs.LocationDtos;
using TABP.Domain.Entities;

namespace TABP.API.Profiles
{
    public class LocationUrlResolver : IValueResolver<Location, LocationDto, List<Link>>
    {
        public List<Link> Resolve(Location source, LocationDto destination, List<Link> destMember, ResolutionContext context)
        {
            var links = new List<Link>
            {
            new Link { Rel = "city", Href = $"/api/hotel/location/city/{source.CityId}", Method = "GET" }
            };

            return links;
        }
    }
}
