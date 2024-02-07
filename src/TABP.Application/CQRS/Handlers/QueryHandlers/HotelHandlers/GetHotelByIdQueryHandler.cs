using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Queries.HotelQueries;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.QueryHandlers.HotelQueryHandlers
{
    public class GetHotelByIdQueryHandler : IRequestHandler<GetHotelByIdQuery, Result<Hotel>>
    {
        private readonly IHotelRepository _hotelRepository;
        public GetHotelByIdQueryHandler(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public async Task<Result<Hotel>> Handle(GetHotelByIdQuery request, CancellationToken cancellationToken)
        {
            var hotel = await _hotelRepository.GetHotelById(request.HotelId);
            if (hotel != null)
            {
                return Result<Hotel>.Success(hotel);
            }
            else
            {
                return Result<Hotel>.Failure("Hotel Not Found.");
            }
        }
    }
}
