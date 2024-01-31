using MediatR;
using TABP.API.CQRS.Handlers;

namespace TABP.Application.CQRS.Commands
{
    public class SaveRoomChangesCommand : IRequest<Result<bool>>
    {
    }
}
