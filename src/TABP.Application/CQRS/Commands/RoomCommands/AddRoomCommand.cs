using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Commands.RoomCommands
{
    public class AddRoomCommand : IRequest<Result<Room>>
    {
        public Guid HotelId { get; set; }
        public Guid RoomTypeId { get; set; }
        public int RoomNumber { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }
    }
}
