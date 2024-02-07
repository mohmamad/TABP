using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Commands.UserCommands;
using TABP.Domain.Entities;
using TABP.Infrastructure.Repositories;

namespace TABP.Application.CQRS.Handlers.CommandHandlers.UserHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<User>>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.User.Email);
            if (user == null)
            {
                await _userRepository.AddUserAsync(request.User);
                var foundUser = await _userRepository.GetUserByEmailAsync(request.User.Email);
                return Result<User>.Success(foundUser);
            }
            else
            {
                return Result<User>.Failure("Email Already Exists!");
            }

        }
    }
}
