using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Queries.RoomQueries
{
    public class GetRoomTypeByIdQuery : IRequest<Result<RoomType>>
    {
        public Guid RoomTypeId { get; set; }
    }
}
