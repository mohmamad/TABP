using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Queries.RoomQueries
{
    public class GetRoomsQuery : IRequest<Result<IEnumerable<Room>>>
    {
        public Guid? RoomId;
        public Guid? HotelId;
        public Guid? RoomTypeId;
        public int? RoomNumber;
        public double? Price;
        public int? Capacity;
        public double? MaxPrice;
        public double? MinPrice;
        public int PageSize = 30;
        public int Page = 1;
    }
}
