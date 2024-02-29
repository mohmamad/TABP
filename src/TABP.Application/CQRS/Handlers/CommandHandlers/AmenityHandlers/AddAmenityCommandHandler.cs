using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Commands.AmenityCommands;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.CommandHandlers.AmenityHandlers
{
    public class AddAmenityCommandHandler : IRequestHandler<AddAmenityCommand, Result<Amenity>>
    {
        private readonly IAmenityRepository _amenityRepository;
        public AddAmenityCommandHandler(IAmenityRepository amenityRepository)
        {
            _amenityRepository = amenityRepository;
        }
        public async Task<Result<Amenity>> Handle(AddAmenityCommand request, CancellationToken cancellationToken)
        {
            var amenity = await _amenityRepository.AddAmenityAsync(new Amenity
            {
                HotelId = request.HotleId,
                Name = request.Name,
                Description = request.Description,
            });

            return Result<Amenity>.Success(amenity);
        }
    }
}
