using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Queries.HotelQueries;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.QueryHandlers.HotelHandlers
{
    public class GetLatestVisitedHotelsForUserQueryHandler : IRequestHandler<GetLatestVisitedHotelsForUserQuery, Result<IEnumerable<Hotel>>>
    {
        private readonly IHotelRepository _hotelRepository;
        public GetLatestVisitedHotelsForUserQueryHandler(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public async Task<Result<IEnumerable<Hotel>>> Handle(GetLatestVisitedHotelsForUserQuery request, CancellationToken cancellationToken)
        {
            var hotels = await _hotelRepository.GetLatestVisitedHotelForUser(request.UserId);
            
            if (hotels != null)
            {
                return Result<IEnumerable<Hotel>>.Success(hotels);
            }
            else
            {
                return Result<IEnumerable<Hotel>>.Failure("Hotel Not Found!");
            }

        }

    }
}
