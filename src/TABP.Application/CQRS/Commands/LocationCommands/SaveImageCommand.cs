using MediatR;
using Microsoft.AspNetCore.Http;
using TABP.API.CQRS.Handlers;

namespace TABP.Application.CQRS.Commands.LocationCommands
{
    public class SaveImageCommand : IRequest<Result<string>>
    {
        public string FileName { get; set; }
        public IFormFile CityImage { get; set; }
    }
}
