using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Queries;
using TABP.Domain.Entities;
using TABP.Infrastructure.Repositories;

namespace TABP.Application.CQRS.Handlers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Result<IEnumerable<User>>>
    {
        private readonly IUserRepository _userRepository;
        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<IEnumerable<User>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUsersAsync
                (
                request.UserId,
                request.FirstName,
                request.LastName,
                request.Email,
                request.BirthDate,
                request.UserLevel,
                request.PageSize,
                request.Page
                );

            return Result<IEnumerable<User>>.Success(user);

        }
    }
}
