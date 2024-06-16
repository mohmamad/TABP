using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Commands.UserCommands;
using TABP.Infrastructure.Repositories;

namespace TABP.Application.CQRS.Handlers.CommandHandlers.UserHandlers
{
    public class SaveChangesCommandHandler : IRequestHandler<SaveChangesCommand, Result<bool>>
    {
        private IUserRepository _userRepository;
        public SaveChangesCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<bool>> Handle(SaveChangesCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.SaveChangesAsync();
            if (result)
            {
                return Result<bool>.Success();
            }
            else
            {
                return Result<bool>.Failure("Failed to save changes.");
            }
        }
    }
}
