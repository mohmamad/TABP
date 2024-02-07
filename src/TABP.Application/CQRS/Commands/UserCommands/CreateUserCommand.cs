using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Commands.UserCommands
{
    public class CreateUserCommand : IRequest<Result<User>>
    {
        public User User { get; set; }
    }
}
