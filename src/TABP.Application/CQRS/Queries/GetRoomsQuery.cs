using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Queries
{
    public class GetRoomsQuery : IRequest<Result<IEnumerable<Room>>>
    {
        public Guid? RoomId;
        public Guid? HotelId;
        public Guid? RoomTypeId;
        public int? RoomNumber;
        public double? Price;
        public int? Capacity;
        public bool? isAvailable;
        public int PageSize = 30;
        public int Page = 1;
    }
}
