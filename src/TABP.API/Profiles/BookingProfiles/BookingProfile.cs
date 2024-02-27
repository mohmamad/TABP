using AutoMapper;
using TABP.API.DTOs.BookingDtos;
using TABP.API.DTOs.CardItemDtos;
using TABP.Domain.Entities;

namespace TABP.API.Profiles.BookingProfiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingDto>()
                .ForMember(dest => dest.Links, opt => opt.MapFrom<BookingURLResolver>());
        }
    }
}
