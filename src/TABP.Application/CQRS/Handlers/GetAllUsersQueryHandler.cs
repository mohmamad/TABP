using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Queries;
using TABP.Application.Models;
using TABP.Infrastructure.Repositories;

namespace TABP.Application.CQRS.Handlers
{
    //public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Result<IEnumerable<UserModel>>>
    //{
    //    private readonly IUserRepository _userRepository;
    //    GetAllUsersQueryHandler(IUserRepository userRepository)
    //    {
    //        _userRepository = userRepository;
    //    }

    //    public Task<Result<IEnumerable<UserModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
