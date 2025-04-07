using MediatR;
using WebApi.CQRS.Application.Errors;
using WebApi.CQRS.Common;
using WebApi.CQRS.Domain.Repositories;

namespace WebApi.CQRS.Application.UseCases.Rooms.Commands;

public class UpdateRoomCommandHandler(IRoomRepository roomRepository) : IRequestHandler<UpdateRoomCommand, Result>
{
    public async Task<Result> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
        var room = await roomRepository.GetByIdAsync(request.RoomId, cancellationToken);
        
        if (room is null)
            return Result.Failure(RoomErrors.RoomNotFound(request.RoomId.ToString()));
        
        if (request.Name is not null)
            room.Name = request.Name;
        
        if (request.Capacity.HasValue)
            room.Capacity = request.Capacity.Value;
        
        if (request.Location is not null)
            room.Location = request.Location;
        
        await roomRepository.UpdateAsync(room, cancellationToken);
        
        await roomRepository.SaveChangesAsync(cancellationToken);
        
        return Result.Success();
    }
}