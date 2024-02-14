using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Queries.RoomQueries
{
    public class GetRoomsWithFeatureddealsByHotelIdQuery : IRequest<Result<IEnumerable<Room>>>
    {
        public Guid HotelId { get; set; }
    }
}
