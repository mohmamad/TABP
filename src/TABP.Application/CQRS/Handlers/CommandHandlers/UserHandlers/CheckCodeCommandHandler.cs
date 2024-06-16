using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Commands.UserCommands;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.CommandHandlers.UserHandlers
{
    public class CheckCodeCommandHandler : IRequestHandler<CheckCodeCommand, Result<string>>
    {
        private readonly IResestPasswordRepository _resestPasswordRepository;

        public CheckCodeCommandHandler(IResestPasswordRepository resestPasswordRepository)
        {
            _resestPasswordRepository = resestPasswordRepository;
        }

        public async Task<Result<string>> Handle(CheckCodeCommand request, CancellationToken cancellationToken)
        {
            bool isValid = await _resestPasswordRepository.IsCodeValid(request.Code);
            if (isValid)
            {
                return Result<string>.Success("Valid code.");
            }

            return Result<string>.Failure("Code not valid.");
        }
    }
}
