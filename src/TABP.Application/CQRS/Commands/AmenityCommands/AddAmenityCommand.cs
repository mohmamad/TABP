using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Commands.AmenityCommands
{
    public class AddAmenityCommand : IRequest<Result<Amenity>>
    {
        public Guid HotleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
