using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.Models;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Commands
{
    public class CreateUserCommand : IRequest<Result<UserModel>>
    {
        public User User { get; set; }
    }
}
