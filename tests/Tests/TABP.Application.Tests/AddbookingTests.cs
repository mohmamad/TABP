using MediatR;
using Moq;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Commands.BookingCommands;
using TABP.Application.CQRS.Handlers.CommandHandlers.BookingHandler;
using TABP.Application.CQRS.Queries.CartItemQueries;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;
using TABP.Infrastructure.Repositories;

namespace TABP.Application.Tests
{
    public class AddbookingTests
    {
        [Fact]
        public async void AddbookingFromCartTest()
        {
            // Arrange
            var bookingRepositoryMock = new Mock<IBookingRepository>();
            var mediatorMock = new Mock<IMediator>();
            var roomRepositoryMock = new Mock<IRoomRepository>();
            var cartItemRepositoryMock = new Mock<ICartItemRepository>();
            var invoiceEmailServiceMock = new Mock<IInvoiceEmailService>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var hotelRepositoryMock = new Mock<IHotelRepository>();
            var transactionServiceMock = new Mock<ITransactionService>();

            var handler = new AddBookingFromCartCommandHandler(
                bookingRepositoryMock.Object,
                mediatorMock.Object,
                roomRepositoryMock.Object,
                cartItemRepositoryMock.Object,
                invoiceEmailServiceMock.Object,
                userRepositoryMock.Object,
                hotelRepositoryMock.Object,
                transactionServiceMock.Object
            );

            var cartItems = new List<CartItem>();

            cartItems.Add(new CartItem
            {
                CartItemId = new Guid(),
                UserId = new Guid(),
                RoomId = new Guid(),
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                RoomStatus = Domain.Enums.RoomStatus.Available
            });

            IEnumerable<CartItem> items = cartItems;

            mediatorMock.Setup(m => m.Send(It.IsAny<GetCartItemByUserIdQurey>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Result<IEnumerable<CartItem>>.Success(items));

            roomRepositoryMock.Setup(r => r.GetRoomByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new Room());

            bookingRepositoryMock.Setup(b => b.IsRoomAvailable
            (It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .ReturnsAsync(true);

            hotelRepositoryMock.Setup(h => h.GetHotelById(It.IsAny<Guid>()))
                .ReturnsAsync(new Hotel());

            userRepositoryMock.Setup(u => u.GetUserByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new User());

            // Act
            var result = await handler.Handle(new AddBookingFromCartCommand(), CancellationToken.None);

            // Assert
            Assert.Equal(1, result.Data.Count());

        }


        [Fact]
        public async void AddbookingFromCartTest_RoomNotFound()
        {
            // Arrange
            var bookingRepositoryMock = new Mock<IBookingRepository>();
            var mediatorMock = new Mock<IMediator>();
            var roomRepositoryMock = new Mock<IRoomRepository>();
            var cartItemRepositoryMock = new Mock<ICartItemRepository>();
            var invoiceEmailServiceMock = new Mock<IInvoiceEmailService>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var hotelRepositoryMock = new Mock<IHotelRepository>();
            var transactionServiceMock = new Mock<ITransactionService>();

            var handler = new AddBookingFromCartCommandHandler(
                bookingRepositoryMock.Object,
                mediatorMock.Object,
                roomRepositoryMock.Object,
                cartItemRepositoryMock.Object,
                invoiceEmailServiceMock.Object,
                userRepositoryMock.Object,
                hotelRepositoryMock.Object,
                transactionServiceMock.Object
            );

            var cartItems = new List<CartItem>();

            cartItems.Add(new CartItem
            {
                CartItemId = new Guid(),
                UserId = new Guid(),
                RoomId = new Guid(),
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                RoomStatus = Domain.Enums.RoomStatus.Available
            });

            IEnumerable<CartItem> items = cartItems;

            mediatorMock.Setup(m => m.Send(It.IsAny<GetCartItemByUserIdQurey>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Result<IEnumerable<CartItem>>.Success(items));

            roomRepositoryMock.Setup(r => r.GetRoomByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Room)null);

            bookingRepositoryMock.Setup(b => b.IsRoomAvailable
            (It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .ReturnsAsync(true);

            hotelRepositoryMock.Setup(h => h.GetHotelById(It.IsAny<Guid>()))
                .ReturnsAsync(new Hotel());

            userRepositoryMock.Setup(u => u.GetUserByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new User());

            // Act
            var result = await handler.Handle(new AddBookingFromCartCommand(), CancellationToken.None);

            // Assert
            Assert.Equal("Room Not Found", result.ErrorMessage);

        }



        [Fact]
        public async void AddbookingFromCartTest_RoomNotAvailable()
        {
            // Arrange
            var bookingRepositoryMock = new Mock<IBookingRepository>();
            var mediatorMock = new Mock<IMediator>();
            var roomRepositoryMock = new Mock<IRoomRepository>();
            var cartItemRepositoryMock = new Mock<ICartItemRepository>();
            var invoiceEmailServiceMock = new Mock<IInvoiceEmailService>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var hotelRepositoryMock = new Mock<IHotelRepository>();
            var transactionServiceMock = new Mock<ITransactionService>();

            var handler = new AddBookingFromCartCommandHandler(
                bookingRepositoryMock.Object,
                mediatorMock.Object,
                roomRepositoryMock.Object,
                cartItemRepositoryMock.Object,
                invoiceEmailServiceMock.Object,
                userRepositoryMock.Object,
                hotelRepositoryMock.Object,
                transactionServiceMock.Object
            );

            var cartItems = new List<CartItem>();

            cartItems.Add(new CartItem
            {
                CartItemId = new Guid(),
                UserId = new Guid(),
                RoomId = new Guid(),
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                RoomStatus = Domain.Enums.RoomStatus.Available
            });

            IEnumerable<CartItem> items = cartItems;

            mediatorMock.Setup(m => m.Send(It.IsAny<GetCartItemByUserIdQurey>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Result<IEnumerable<CartItem>>.Success(items));

            roomRepositoryMock.Setup(r => r.GetRoomByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new Room());

            bookingRepositoryMock.Setup(b => b.IsRoomAvailable
            (It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .ReturnsAsync(false);

            hotelRepositoryMock.Setup(h => h.GetHotelById(It.IsAny<Guid>()))
                .ReturnsAsync(new Hotel());

            userRepositoryMock.Setup(u => u.GetUserByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new User());

            // Act
            var result = await handler.Handle(new AddBookingFromCartCommand(), CancellationToken.None);

            // Assert
            Assert.Equal("The room in not available.", result.ErrorMessage);

        }


        [Fact]
        public async void AddbookingFromCartTest_InvalidDate()
        {
            // Arrange
            var bookingRepositoryMock = new Mock<IBookingRepository>();
            var mediatorMock = new Mock<IMediator>();
            var roomRepositoryMock = new Mock<IRoomRepository>();
            var cartItemRepositoryMock = new Mock<ICartItemRepository>();
            var invoiceEmailServiceMock = new Mock<IInvoiceEmailService>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var hotelRepositoryMock = new Mock<IHotelRepository>();
            var transactionServiceMock = new Mock<ITransactionService>();

            var handler = new AddBookingFromCartCommandHandler(
                bookingRepositoryMock.Object,
                mediatorMock.Object,
                roomRepositoryMock.Object,
                cartItemRepositoryMock.Object,
                invoiceEmailServiceMock.Object,
                userRepositoryMock.Object,
                hotelRepositoryMock.Object,
                transactionServiceMock.Object
            );

            var cartItems = new List<CartItem>();

            cartItems.Add(new CartItem
            {
                CartItemId = new Guid(),
                UserId = new Guid(),
                RoomId = new Guid(),
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(-1),
                RoomStatus = Domain.Enums.RoomStatus.Available
            });

            IEnumerable<CartItem> items = cartItems;

            mediatorMock.Setup(m => m.Send(It.IsAny<GetCartItemByUserIdQurey>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Result<IEnumerable<CartItem>>.Success(items));

            roomRepositoryMock.Setup(r => r.GetRoomByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new Room());

            bookingRepositoryMock.Setup(b => b.IsRoomAvailable
            (It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .ReturnsAsync(true);

            hotelRepositoryMock.Setup(h => h.GetHotelById(It.IsAny<Guid>()))
                .ReturnsAsync(new Hotel());

            userRepositoryMock.Setup(u => u.GetUserByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new User());

            // Act
            var result = await handler.Handle(new AddBookingFromCartCommand(), CancellationToken.None);

            // Assert
            Assert.Equal("Invalid Date.", result.ErrorMessage);

        }


        [Fact]
        public async void AddbookingFromCartTest_EmptyCart()
        {
            // Arrange
            var bookingRepositoryMock = new Mock<IBookingRepository>();
            var mediatorMock = new Mock<IMediator>();
            var roomRepositoryMock = new Mock<IRoomRepository>();
            var cartItemRepositoryMock = new Mock<ICartItemRepository>();
            var invoiceEmailServiceMock = new Mock<IInvoiceEmailService>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var hotelRepositoryMock = new Mock<IHotelRepository>();
            var transactionServiceMock = new Mock<ITransactionService>();

            var handler = new AddBookingFromCartCommandHandler(
                bookingRepositoryMock.Object,
                mediatorMock.Object,
                roomRepositoryMock.Object,
                cartItemRepositoryMock.Object,
                invoiceEmailServiceMock.Object,
                userRepositoryMock.Object,
                hotelRepositoryMock.Object,
                transactionServiceMock.Object
            );

            IEnumerable<CartItem> items = new List<CartItem>(); ;

            mediatorMock.Setup(m => m.Send(It.IsAny<GetCartItemByUserIdQurey>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Result<IEnumerable<CartItem>>.Success(items));

            roomRepositoryMock.Setup(r => r.GetRoomByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new Room());

            bookingRepositoryMock.Setup(b => b.IsRoomAvailable
            (It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .ReturnsAsync(true);

            hotelRepositoryMock.Setup(h => h.GetHotelById(It.IsAny<Guid>()))
                .ReturnsAsync(new Hotel());

            userRepositoryMock.Setup(u => u.GetUserByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new User());

            // Act
            var result = await handler.Handle(new AddBookingFromCartCommand(), CancellationToken.None);

            // Assert
            Assert.Equal("The Cart is empty.", result.ErrorMessage);

        }



    }
}


