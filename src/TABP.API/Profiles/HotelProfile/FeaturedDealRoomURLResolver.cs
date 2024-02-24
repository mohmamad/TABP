using AutoMapper;
using TABP.API.DTOs;
using TABP.API.DTOs.FeaturedDealsDtos;
using TABP.Domain.Entities;

namespace TABP.API.Profiles.FeaturedDealsProfile
{
    public class FeaturedDealRoomURLResolver : IValueResolver<Hotel, FeaturedDealHotelDto, List<Link>>
    {
        public string Resolve(Hotel source, FeaturedDealHotelDto destination, string destMember, ResolutionContext context)
        {
            return $"/api/room/featuredDeal/{source.HotelId}";
        }

        public List<Link> Resolve(Hotel source, FeaturedDealHotelDto destination, List<Link> destMember, ResolutionContext context)
        {
            var links = new List<Link>
            {
            new Link { Rel = "rooms", Href = $"/api/room/featuredDeal/{source.HotelId}", Method = "GET" }
            };

            return links;
        }
    }
}
