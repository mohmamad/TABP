using MediatR;
using Microsoft.IdentityModel.Tokens;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Queries.HotelQueries;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.QueryHandlers.HotelHandlers
{
    public class GetHotelTypeQueryHandler : IRequestHandler<GetHotelTypeQuery, Result<List<HotelType>>>
    {
        private readonly IHotelTypeRepository _hotelTypeRepository;
        public GetHotelTypeQueryHandler(IHotelTypeRepository hotelTypeRepository)
        {
            _hotelTypeRepository = hotelTypeRepository;
        }
        public async Task<Result<List<HotelType>>> Handle(GetHotelTypeQuery request, CancellationToken cancellationToken)
        {
            var hotelTypes = await _hotelTypeRepository.GetHotelTypesAsync();
            if (hotelTypes.IsNullOrEmpty())
            {
                return Result<List<HotelType>>.Failure("Hotel Types Not Found.");
            }
            return Result<List<HotelType>>.Success(hotelTypes);
        }
    }
}
