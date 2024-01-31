using MediatR;
using TABP.API.CQRS.Handlers;

namespace TABP.Application.CQRS.Commands
{
    public class DeleteUserByIdCommand : IRequest<Result<string>>
    {
        public Guid UserId { get; set; }
    }
}
