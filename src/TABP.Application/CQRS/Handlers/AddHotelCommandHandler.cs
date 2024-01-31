using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Commands;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers
{
    public class AddHotelCommandHandler : IRequestHandler<AddHotelCommand, Result<Hotel>>
    {
        private readonly IHotelRepository _hotelRepository;
        public AddHotelCommandHandler(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public async Task<Result<Hotel>> Handle(AddHotelCommand request, CancellationToken cancellationToken)
        {
            

            var result = await _hotelRepository.GetHotelTypeByIdAsync(request.HotelTypeId);
            if(result != null)
            {
                var hotel = new Hotel
                {
                    HotelName = request.HotelName,
                    HotelDescription = request.HotelDescription,
                    Rating = request.Rating,
                    Amenities = request.Amenities,
                    HotelTypeId = result.HotelTypeId
                };
                await _hotelRepository.AddHotelAsync(hotel);
                return Result<Hotel>.Success(hotel);
            }
            else
            {
                return Result<Hotel>.Failure("Hotel type does not exist.");
            }
            



        }
    }
}
