using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Commands.LocationCommands;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.CommandHandlers.LocationHandlers
{
    public class SaveImageCommandHandler : IRequestHandler<SaveImageCommand, Result<string>>
    {
        private readonly IImageStorageService _imageStorageService;
        public SaveImageCommandHandler(IImageStorageService imageStorageService)
        {
            _imageStorageService = imageStorageService;
        }

        public async Task<Result<string>> Handle(SaveImageCommand request, CancellationToken cancellationToken)
        {
            string filePath = await _imageStorageService.StoreImage(request.CityImage, request.FileName);

            return Result<string>.Success(filePath);
        }

    }
}
