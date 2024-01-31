using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Commands;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers
{
    public class SaveHotelChangesCommandHandler : IRequestHandler<SaveHotelChangesCommand, Result<bool>>
    {
        private readonly IHotelRepository _hotelRepository;
        public SaveHotelChangesCommandHandler(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public async Task<Result<bool>> Handle(SaveHotelChangesCommand request, CancellationToken cancellationToken)
        {
           var result = await _hotelRepository.SaveChangesAsync();
            if (result)
            {
                return Result<bool>.Success();
            }
            else
            {
                return Result<bool>.Failure("Failed to save changes.");
            }
        }
    }
}
