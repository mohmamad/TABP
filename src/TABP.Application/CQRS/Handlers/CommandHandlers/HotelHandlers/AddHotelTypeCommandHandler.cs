using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Commands.HotelCommands;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.CommandHandlers.HotelHandlers
{
    public class AddHotelTypeCommandHandler : IRequestHandler<AddHotelTypeCommand, Result<HotelType>>
    {
        private IHotelTypeRepository _hotelTypeRepository;
        public AddHotelTypeCommandHandler(IHotelTypeRepository hotelTypeRepository)
        {
            _hotelTypeRepository = hotelTypeRepository;
        }

        public async Task<Result<HotelType>> Handle(AddHotelTypeCommand request, CancellationToken cancellationToken)
        {
            var hotelType = new HotelType
            {
                HotelTypeId = new Guid(),
                Type = request.HotelType
            };

            var result = await _hotelTypeRepository.AddHotelTypeAsync(hotelType);

            return Result<HotelType>.Success(result);
        }
    }
}
