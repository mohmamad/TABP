using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Commands.UserCommands;
using TABP.Infrastructure.Repositories;

namespace TABP.Application.CQRS.Handlers.CommandHandlers.UserHandlers
{
    public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand, Result<string>>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserByIdCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result<string>> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteUser(request.UserId);
            return null;
        }
    }
}
