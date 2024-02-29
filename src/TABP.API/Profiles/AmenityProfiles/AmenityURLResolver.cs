using AutoMapper;
using TABP.API.DTOs;
using TABP.API.DTOs.AmenityDtos;
using TABP.Domain.Entities;

namespace TABP.API.Profiles.AmenityProfiles
{
    public class AmenityURLResolver : IValueResolver<Amenity, AmenityDto, List<Link>>
    {
        public List<Link> Resolve(Amenity source, AmenityDto destination, List<Link> destMember, ResolutionContext context)
        {
            var links = new List<Link>
            {
             new Link { Rel = "hotel", Href = $"/api/hotel?hotelId={source.HotelId}", Method = "GET" }
            };

            return links;
        }
    }
}
