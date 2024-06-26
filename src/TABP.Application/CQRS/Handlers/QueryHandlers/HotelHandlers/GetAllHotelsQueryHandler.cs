using MediatR;
using Microsoft.IdentityModel.Tokens;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Queries.HotelQueries;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.QueryHandlers.HotelHandlers
{
    public class GetAllHotelsQueryHandler : IRequestHandler<GetAllHotelsQuery, Result<List<Hotel>>>
    {
        private readonly IHotelRepository _hotelRepository;
        public GetAllHotelsQueryHandler(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public async Task<Result<List<Hotel>>> Handle(GetAllHotelsQuery request, CancellationToken cancellationToken)
        {
            var hotels = await _hotelRepository.GetAllHotelsAsync(request.Name);
            if (hotels.IsNullOrEmpty()) return Result<List<Hotel>>.Failure("Hotels Not Found.");

            return Result<List<Hotel>>.Success(hotels);
        }
    }
}
