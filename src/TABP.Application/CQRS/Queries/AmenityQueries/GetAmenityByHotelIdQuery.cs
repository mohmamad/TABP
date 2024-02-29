using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Queries.AmenityQueries
{
    public class GetAmenityByHotelIdQuery : IRequest<Result<IEnumerable<Amenity>>>
    {
        public Guid HotelId { get; set; }
    }
}
