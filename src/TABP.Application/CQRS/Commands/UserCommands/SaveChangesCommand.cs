using MediatR;
using TABP.API.CQRS.Handlers;

namespace TABP.Application.CQRS.Commands.UserCommands
{
    public class SaveChangesCommand : IRequest<Result<bool>>
    {
    }
}
