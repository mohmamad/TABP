using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.API.Models;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Commands
{
    public class AuthenticateUserCommand : IRequest<Result<string>>
    {
        public UserCredentials UserCredentials { get; set; }
    }
}
