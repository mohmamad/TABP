using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Commands
{
    public class CreateUserCommand : IRequest<Result<User>>
    {
        public User User { get; set; }
    }
}
