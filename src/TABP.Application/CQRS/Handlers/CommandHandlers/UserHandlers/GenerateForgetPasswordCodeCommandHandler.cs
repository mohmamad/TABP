using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Commands.UserCommands;
using TABP.Application.CQRS.Queries.UserQueries;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.CommandHandlers.UserHandlers
{
    public class GenerateForgetPasswordCodeCommandHandler : IRequestHandler<GenerateForgetPasswordCodeCommand, Result<string>>
    {
        private readonly IResestPasswordRepository _resetPasswordRepository;
        private readonly IEmailService _emailService;
        private readonly IMediator _mediator;

        public GenerateForgetPasswordCodeCommandHandler(
            IResestPasswordRepository resestPasswordRepository,
            IEmailService emailService,
            IMediator mediator
            )
        {
            _resetPasswordRepository = resestPasswordRepository;
            _emailService = emailService;
            _mediator = mediator;
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

            var user = await _mediator.Send(new GetUsersQuery {UserId = null, FirstName = null, LastName = null, 
                Email = request.Email, BirthDate = null, UserLevel = null, Page = 1, PageSize = 1 });

            if (IsAdded)
            {
                await _emailService.PrepareResetPasswordCodeEmail(user.Data.Where(u => u.Email == request.Email).ToList()[0].FirstName, request.Email, code);
                return Result<string>.Success("Code Generated successfully!");
            }
            else
            {
                return Result<string>.Failure("Email Not Found!");
            }

        }
    }
}
