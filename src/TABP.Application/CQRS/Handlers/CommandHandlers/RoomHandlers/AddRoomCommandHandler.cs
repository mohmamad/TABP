using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Commands.RoomCommands;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.CommandHandlers.RoomHandlers
{
    public class AddRoomCommandHandler : IRequestHandler<AddRoomCommand, Result<Room>>
    {
        private readonly IRoomRepository _roomRepository;

        public AddRoomCommandHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<Result<Room>> Handle(AddRoomCommand request, CancellationToken cancellationToken)
        {
            var Room = new Room
            {
                HotelId = request.HotelId,
                RoomNumber = request.RoomNumber,
                RoomTypeId = request.RoomTypeId,
                Capacity = request.Capacity,
                Price = request.Price,
            };

            try
            {
                await _roomRepository.AddRoomAsync(Room);
                return Result<Room>.Success(Room);
            }
            catch (Exception ex)
            {
                return Result<Room>.Failure("the hotel you are trying to add the room to does not exist." + ex.Message);
            }


            throw new NotImplementedException();
        }
    }
}
