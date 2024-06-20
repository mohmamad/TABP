using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Commands.RoomCommands
{
    public class AddRoomImageCommand : IRequest<Result<List<RoomImage>>>
    {
        public Guid RoomId { get; set; }
        public List<string> RoomImageBaths { get; set; }
    }
}
