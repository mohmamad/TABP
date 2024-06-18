using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Commands.UserCommands;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.CommandHandlers.UserHandlers
{
    public class CheckCodeCommandHandler : IRequestHandler<CheckCodeCommand, Result<string>>
    {
        private readonly IResestPasswordRepository _resestPasswordRepository;
        private readonly IConfiguration _config;

        public CheckCodeCommandHandler(IResestPasswordRepository resestPasswordRepository, IConfiguration configuration)
        {
            _resestPasswordRepository = resestPasswordRepository;
            _config = configuration;
        }

        public async Task<Result<string>> Handle(CheckCodeCommand request, CancellationToken cancellationToken)
        {
            bool isValid = await _resestPasswordRepository.IsCodeValid(request.Code);
            if (isValid)
            {
                var key = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(_config["Authentication:Key"]));
                var signingCredentials = new SigningCredentials(
                    key, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
            {
                new("code", request.Code),
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

            return Result<string>.Failure("Code not valid.");
        }
    }
}
