using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Queries.HotelQueries;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.QueryHandlers.HotelQueryHandlers
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
            if(request.StartDate == null)
            {
                request.StartDate = DateTime.UtcNow;
            }
            if(request.EndDate == null)
            {
                request.EndDate = DateTime.UtcNow.AddDays(1);
            }
            var hotels = await _hotelRepository.GetHotelsAsync
                (
                    request.HotelId,
                    request.HotelName,
                    request.HotelDescription,
                    request.Rating,
                    request.Amenities,
                    request.HotelTypeId,
                    request.HotelType,
                    request.MinPrice,
                    request.MaxPrice,
                    request.StartDate,
                    request.EndDate,
                    request.City,
                    request.PageSize,
                    request.Page
                );
            if( hotels != null )
            {
                return Result<IEnumerable<Hotel>>.Success(hotels);
            }
            else
            {
                return Result<IEnumerable<Hotel>>.Failure("Hotel Not found.");
            }
        }

    }
}
