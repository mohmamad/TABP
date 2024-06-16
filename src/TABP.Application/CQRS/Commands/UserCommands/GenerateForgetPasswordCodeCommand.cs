using MediatR;
using TABP.API.CQRS.Handlers;

namespace TABP.Application.CQRS.Commands.UserCommands
{
    public class GenerateForgetPasswordCodeCommand : IRequest<Result<string>>
    {
        public string Email { get; set; }
    }
}
