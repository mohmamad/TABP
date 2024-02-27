using AutoMapper;
using TABP.API.DTOs;
using TABP.API.DTOs.BookingDtos;
using TABP.API.DTOs.CartItemDtos;
using TABP.Domain.Entities;

namespace TABP.API.Profiles.CartItemProfiles
{
    public class CartItemURLResolver : IValueResolver<CartItem, CartItemDto, List<Link>>
    {
        public List<Link> Resolve(CartItem source, CartItemDto destination, List<Link> destMember, ResolutionContext context)
        {
            var links = new List<Link>
            {
            new Link { Rel = "user", Href = $"/api/users?userId={source.UserId}", Method = "GET" },
            new Link { Rel = "rooms", Href = $"/api/room?roomId={source.RoomId}", Method = "GET" }
            };

            return links;
        }
    }
}
