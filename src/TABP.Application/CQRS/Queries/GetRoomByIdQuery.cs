using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Queries
{
    public class GetRoomByIdQuery : IRequest<Result<Room>>
    {
        public Guid RoomId { get; set; }
    }
}
