using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Queries.HotelQueries;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.QueryHandlers.HotelHandlers
{
    public class GetHotelTypeByIdQueryHandler : IRequestHandler<GetHotelTypeByIdQuery, Result<HotelType>>
    {
        private readonly IHotelTypeRepository _hotelTypeRepository;
        public GetHotelTypeByIdQueryHandler(IHotelTypeRepository hotelTypeRepository)
        {
            _hotelTypeRepository = hotelTypeRepository;
        }
        public async Task<Result<HotelType>> Handle(GetHotelTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var hotelType = await _hotelTypeRepository.GetHotelTypeById(request.hotelTypeId);
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
