using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Commands;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers
{
    public class SaveRoomChangesCommandHandler : IRequestHandler<SaveRoomChangesCommand, Result<bool>>
    {
        private readonly IRoomRepository _roomRepository;
        public SaveRoomChangesCommandHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<Result<bool>> Handle(SaveRoomChangesCommand request, CancellationToken cancellationToken)
        {
            var result = await _roomRepository.SaveChangesAsync();
            if (result)
            {
                return Result<bool>.Success();
            }
            else
            {
                return Result<bool>.Failure("");
            }
        }
    }
}
