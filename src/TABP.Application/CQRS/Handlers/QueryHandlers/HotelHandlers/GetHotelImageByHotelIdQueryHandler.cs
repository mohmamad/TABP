using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Queries.HotelQueries;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.QueryHandlers.HotelHandlers
{
    public class GetHotelImageByHotelIdQueryHandler : IRequestHandler<GetHotelImageByHotelIdQuery, Result<HotelImage>>
    {
        private readonly IHotelRepository _hotelRepository; 
        public GetHotelImageByHotelIdQueryHandler(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public async Task<Result<HotelImage>> Handle(GetHotelImageByHotelIdQuery request, CancellationToken cancellationToken)
        {
            var hotelImage = await _hotelRepository.GetHotelImageByHotelIdAsync(request.HotelId);
            if(hotelImage != null)
            {
                return Result<HotelImage>.Success(hotelImage);
            }
            else
            {
                return Result<HotelImage>.Failure("Hotel Image Not Found.");
            }
        }
    }
}
