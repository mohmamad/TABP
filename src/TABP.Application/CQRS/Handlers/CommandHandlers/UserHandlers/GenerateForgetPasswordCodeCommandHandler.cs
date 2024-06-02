using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Commands.UserCommands;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.CommandHandlers.UserHandlers
{
    public class GenerateForgetPasswordCodeCommandHandler : IRequestHandler<GenerateForgetPasswordCodeCommand ,Result<string>>
    {
        private readonly IResestPasswordRepository _resetPasswordRepository; 
        public GenerateForgetPasswordCodeCommandHandler(IResestPasswordRepository resestPasswordRepository)
        {
            _resetPasswordRepository = resestPasswordRepository;
        }

        public string GenerateRandomCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            char[] stringChars = new char[length];

            for (int i = 0; i < length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }


        public async Task<Result<string>> Handle(GenerateForgetPasswordCodeCommand request, CancellationToken cancellationToken)
        {
            string code = GenerateRandomCode(5);

            bool IsAdded = await _resetPasswordRepository.AddResetPasswordCode(request.Email, code);

            if (IsAdded)
            {
                return Result<string>.Success("Code Generated successfully!");
            }
            else
            {
                return Result<string>.Failure("Email Not Found!");
            }
            
        }
    }
}
