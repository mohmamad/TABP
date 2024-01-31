using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Queries;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers
{
    public class GetHotelsQueryHandler : IRequestHandler<GetHotelsQuery, Result<IEnumerable<Hotel>>>
    {
        private readonly IHotelRepository _hotelRepository;
        public GetHotelsQueryHandler(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public async Task<Result<IEnumerable<Hotel>>> Handle(GetHotelsQuery request, CancellationToken cancellationToken)
        {
            var hotels = await _hotelRepository.GetHotelsAsync
                (
                    request.HotelId,
                    request.HotelName,
                    request.HotelDescription,
                    request.Rating,
                    request.Amenities,
                    request.HotelTypeId,
                    request.PageSize,
                    request.Page
                );
            
            return Result<IEnumerable<Hotel>>.Success(hotels);
        }
    }
}
