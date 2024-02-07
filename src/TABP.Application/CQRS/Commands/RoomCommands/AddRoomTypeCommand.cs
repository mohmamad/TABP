using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Commands.RoomCommands
{
    public class AddRoomTypeCommand : IRequest<Result<RoomType>>
    {
        public string Type { get; set; }
    }
}
