using AutoMapper;
using TABP.API.DTOs.FeaturedDealsDtos;
using TABP.Domain.Entities;

namespace TABP.API.Profiles.FeaturedDealsProfile
{
    public class FeaturedDealRoomURLResolver : IValueResolver<Hotel, FeaturedDealHotelDto, string>
    {
        public string Resolve(Hotel source, FeaturedDealHotelDto destination, string destMember, ResolutionContext context)
        {
            return $"/api/room/featuredDeal/{source.HotelId}";
        }
    }
}
