using MediatR;
using WebApi.CQRS.Application.Errors;
using WebApi.CQRS.Common;
using WebApi.CQRS.Domain.Repositories;

namespace WebApi.CQRS.Application.UseCases.Rooms.Commands;

public class DeleteRoomCommandHandler(IRoomRepository roomRepository) : IRequestHandler<DeleteRoomCommand, Result>
{
    public async Task<Result> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
    {
        var room = await roomRepository.GetByIdAsync(request.RoomId, cancellationToken);
        
        if (room is null)
            return Result.Failure(RoomErrors.RoomNotFound(request.RoomId.ToString()));
        
        await roomRepository.DeleteAsync(room, cancellationToken);
        
        await roomRepository.SaveChangesAsync(cancellationToken);
        
        return Result.Success();
    }
}