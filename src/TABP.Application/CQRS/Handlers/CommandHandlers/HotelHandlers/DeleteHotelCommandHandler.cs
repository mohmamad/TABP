using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Commands.HotelCommands;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.CommandHandlers.HotelHandlers
{
    public class DeleteHotelCommandHandler : IRequestHandler<DeleteHotelCommand, Result<string>>
    {
        private readonly IHotelRepository _hotelRepository;
        public DeleteHotelCommandHandler(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public async Task<Result<string>> Handle(DeleteHotelCommand request, CancellationToken cancellationToken)
        {
            await _hotelRepository.DeleteHotel(request.HotelId);
            return Result<string>.Success("Hotel Deleted Successfully.");
        }
    }
}
