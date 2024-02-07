using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Queries.UserQueries
{
    public class GetUsersQuery : IRequest<Result<IEnumerable<User>>>
    {
        public Guid? UserId;
        public string? FirstName;
        public string? LastName;
        public string? Email;
        public DateTime? BirthDate;
        public int? UserLevel;
        public int PageSize;
        public int Page;
    }
}
