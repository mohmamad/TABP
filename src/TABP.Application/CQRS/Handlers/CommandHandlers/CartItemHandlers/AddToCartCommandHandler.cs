using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Commands.CartItemCommands;
using TABP.Domain.Entities;
using TABP.Domain.Enums;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.CommandHandlers.CartItemCommandHandlers
{
    public class AddToCartCommandHandler : IRequestHandler<AddToCartCommand, Result<Dictionary<string, double>>>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly ICartItemRepository _cartItemRepository;
        public AddToCartCommandHandler(IBookingRepository bookingRepository, IRoomRepository roomRepository, ICartItemRepository cartItemRepository)
        {
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;
            _cartItemRepository = cartItemRepository;
        }
        public async Task<Result<Dictionary<string, double>>> Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            bool canAddToCart = await _cartItemRepository.CanAddToCart(request.RoomId,request.StartDate,request.EndDate);

            if (!canAddToCart)
            {
                return Result<Dictionary<string, double>>.Failure("Item Cant Be Added.");
            }

            var room = await _roomRepository.GetRoomByIdAsync(request.RoomId);

            if (room == null)
            {
                return Result<Dictionary<string, double>>.Failure("Room Not Found");
            }

            var isRoomAvailable = await _bookingRepository.IsRoomAvailable(request.RoomId, request.StartDate, request.EndDate);

            if (!isRoomAvailable)
            {
                return Result<Dictionary<string, double>>.Failure("The room in not available.");
            }

            if (request.StartDate >= request.EndDate || request.StartDate < DateTime.UtcNow)
            {
                return Result<Dictionary<string, double>>.Failure("Invalid Date.");
            }

            if (room.Capacity >= request.NumberOfResidents)
            {
                var cartItem = new CartItem
                {
                    UserId = request.UserId,
                    RoomId = request.RoomId,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    RoomStatus = RoomStatus.Available
                };

                await _cartItemRepository.AddToCartAsync(cartItem);
                return Result<Dictionary<string, double>>.Success();
            }
            else
            {
                return Result<Dictionary<string, double>>.Failure("No enough capacity in the room.");
            }

        }
    }
}
