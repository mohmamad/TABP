using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Queries.RoomQueries
{
    public class GetRoomTypeByRoomIdQuery : IRequest<Result<RoomType>>
    {
        public Guid RoomId { get; set; }
    }
}
