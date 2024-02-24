using AutoMapper;
using TABP.API.DTOs.FeaturedDealsDtos;
using TABP.API.DTOs.HotelDtos;
using TABP.Domain.Entities;

namespace TABP.API.Profiles.FeaturedDealsProfile
{
    public class FeaturedDealProfile : Profile
    {
        public FeaturedDealProfile()
        {
            CreateMap<FeaturedDeal, FeaturedDealsDto>();

           
        }

    }
}
