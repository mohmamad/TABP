using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.API.Models;

namespace TABP.Application.CQRS.Commands.UserCommands
{
    public class AuthenticateUserCommand : IRequest<Result<string>>
    {
        public UserCredentials UserCredentials { get; set; }
    }
}
