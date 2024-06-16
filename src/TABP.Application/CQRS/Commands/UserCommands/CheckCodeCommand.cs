using MediatR;
using TABP.API.CQRS.Handlers;

namespace TABP.Application.CQRS.Commands.UserCommands
{
    public class CheckCodeCommand : IRequest<Result<string>>
    {
        public string Code { get; set; }
    }
}
