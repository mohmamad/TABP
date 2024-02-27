using AutoMapper;
using TABP.API.DTOs.BookingDtos;
using TABP.API.DTOs.CartItemDtos;
using TABP.API.Profiles.BookingProfiles;
using TABP.Domain.Entities;

namespace TABP.API.Profiles.CartItemProfiles
{
    public class CartItemProfile : Profile
    {
        public CartItemProfile()
        {
            CreateMap<CartItem, CartItemDto>()
                .ForMember(dest => dest.Links, opt => opt.MapFrom<CartItemURLResolver>());
        }
    }
}
