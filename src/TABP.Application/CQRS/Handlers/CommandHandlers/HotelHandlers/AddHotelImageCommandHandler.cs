using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Commands.HotelCommands;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.CommandHandlers.HotelHandlers
{
    public class AddHotelImageCommandHandler : IRequestHandler<AddHotelImageCommand, Result<HotelImage>>
    {
        private IHotelRepository _hotelRepository;
        public AddHotelImageCommandHandler(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository; 
        }
        public async Task<Result<HotelImage>> Handle(AddHotelImageCommand request, CancellationToken cancellationToken)
        {
            var hotelImage = await _hotelRepository.AddHotelImageAsync(new HotelImage
            {
                HotelId = request.HotelId,
                ImagePath = request.HotelImagePath
            });
            return Result<HotelImage>.Success(hotelImage);
            
        }
    }
}
