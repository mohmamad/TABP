using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Queries.HotelQueries;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.QueryHandlers.HotelHandlers
{
    public class GetHotelTypeByHotelIdQueryHandler : IRequestHandler<GetHotelTypeByHotelIdQuery, Result<HotelType>>
    {
        private readonly IHotelTypeRepository _hotelTypeRepository;
        public GetHotelTypeByHotelIdQueryHandler(IHotelTypeRepository hotelTypeRepository)
        {
            _hotelTypeRepository = hotelTypeRepository;
        }
        public async Task<Result<HotelType>> Handle(GetHotelTypeByHotelIdQuery request, CancellationToken cancellationToken)
        {
            var hotelType = await _hotelTypeRepository.GetHotelTypeByHotelId(request.hotelId);
            if (hotelType != null)
            {
                return Result<HotelType>.Success(hotelType);
            }
            else
            {
                return Result<HotelType>.Failure("Hotel Type Not Found.");
            }
        }
    }
}
