using AutoMapper;
using TABP.API.DTOs.BookingDtos;
using TABP.Domain.Entities;

namespace TABP.API.Profiles.BookingProfiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingDto>()
                .ForMember(dest => dest.RoomURL, opt => opt.MapFrom<RoomURLResolver>())
                .ForMember(dest => dest.UserURL, opt => opt.MapFrom<UserURLResolver>());
        }
    }
}
