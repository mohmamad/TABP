using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Commands.UserCommands;
using TABP.Infrastructure.Repositories;

namespace TABP.Application.CQRS.Handlers.CommandHandlers.UserHandlers
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, Result<string>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;
        public AuthenticateUserCommandHandler(IUserRepository userRepository, IConfiguration configuration)
        {
            _config = configuration;
            _userRepository = userRepository;
        }
        public async Task<Result<string>> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByCredentialsAsync(request.UserCredentials.Email, request.UserCredentials.Password);
            if (user != null)
            {
                var key = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(_config["Authentication:Key"]));
                var signingCredentials = new SigningCredentials(
                    key, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                new("role", ((int)user.UserLevel).ToString())
            };

                var jwtSecurityToken = new JwtSecurityToken
                    (
                        _config["Authentication:Issuer"],
                        _config["Authentication:Audience"],
                        claims,
                        DateTime.UtcNow,
                        DateTime.UtcNow.AddHours(1),
                        signingCredentials
                    );
                var tokenToReturn = new JwtSecurityTokenHandler()
                    .WriteToken(jwtSecurityToken);

                return Result<string>.Success(tokenToReturn);
            }
            else
            {
                return Result<string>.Failure("Wrong Email or Password!");
            }
        }
    }
}
