using AutoMapper;
using TABP.API.DTOs.BookingDtos;
using TABP.Domain.Entities;

namespace TABP.API.Profiles.BookingProfiles
{
    public class UserURLResolver : IValueResolver<Booking, BookingDto, string>
    {
        public string Resolve(Booking source, BookingDto destination, string destMember, ResolutionContext context)
        {
            return $"/api/users?userId={source.UserId}";
        }
    }
}
