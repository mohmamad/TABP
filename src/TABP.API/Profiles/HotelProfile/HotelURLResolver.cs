using AutoMapper;
using Microsoft.AspNetCore.Http;
using TABP.API.DTOs;
using TABP.API.DTOs.HotelDtos;
using TABP.Domain.Entities;

namespace TABP.API.Profiles
{
    public class HotelURLResolver : IValueResolver<Hotel, HotelDto, List<Link>>
    {
        public List<Link> Resolve(Hotel source, HotelDto destination, List<Link> destMember, ResolutionContext context)
        {
            var links = new List<Link>
            {
            new Link { Rel = "hotel type", Href = $"/api/hotel/hotelType/{source.HotelTypeId}", Method = "GET" },
            new Link { Rel = "location", Href = $"/api/hotel/{source.HotelId}/location", Method = "GET" },
            new Link { Rel = "hotel images", Href = $"/api/hotel/hotelImage/{source.HotelId}", Method = "GET" },
            new Link { Rel = "booking", Href = $"/api/hotel/{source.HotelId}/location", Method = "GET" },
            new Link { Rel = "add location", Href = $"/api/hotel/{source.HotelId}/location", Method = "POST" },
            new Link { Rel = "amenities", Href = $"", Method = "GET" },
            new Link { Rel = "add amenities", Href = $"", Method = "POST" }
            };

            return links;
        }
    }
}
