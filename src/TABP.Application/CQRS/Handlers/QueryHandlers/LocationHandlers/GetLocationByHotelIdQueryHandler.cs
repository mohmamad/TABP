using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Queries.LocationQueries;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.QueryHandlers.LocationHandlers
{
    public class GetLocationByHotelIdQueryHandler : IRequestHandler<GetLocationByHotelIdQuery, Result<Location>>
    {
        private readonly ILocationRepository _locationRepository;
        public GetLocationByHotelIdQueryHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        public async Task<Result<Location>> Handle(GetLocationByHotelIdQuery request, CancellationToken cancellationToken)
        {
            var location = await _locationRepository.GetLocationByHotelId(request.HotelId);
            if (location != null)
            {
                return Result<Location>.Success(location);
            }
            else
            {
                return Result<Location>.Failure("Hotel Location Not Found.");
            }
        }
    }
}
