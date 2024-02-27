using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Commands.CartItemCommands
{
    public class AddToCartCommand : IRequest<Result<Dictionary<string, double>>>
    {
        public Guid UserId { get; set; }
        public Guid RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfResidents { get; set; }
    }
}
