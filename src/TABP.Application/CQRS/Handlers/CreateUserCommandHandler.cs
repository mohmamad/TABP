using AutoMapper;
using MediatR;
using TABP.Application.CQRS.Commands;
using TABP.Application.Models;
using TABP.Infrastructure.Repositories;

namespace TABP.API.CQRS.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<UserModel>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IUserRepository userRepository , IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<Result<UserModel>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.User.Email);
            if (user == null)
            {
                await _userRepository.AddUserAsync(request.User);
                var foundUser = await _userRepository.GetUserByEmailAsync(request.User.Email);
                var userModel = _mapper.Map<UserModel>(foundUser);

                return Result<UserModel>.Success(userModel);
            }
            else
            {
                return Result<UserModel>.Failure("Email Already Exists!");
            }

        }
    }
}
