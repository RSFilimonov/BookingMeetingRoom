using MediatR;
using WebApi.CQRS.Common;
using WebApi.CQRS.Domain.Models;
using WebApi.CQRS.Domain.Repositories;

namespace WebApi.CQRS.Application.UseCases.Rooms.Commands;

public class CreateRoomCommandHandler(IRoomRepository roomRepository) : IRequestHandler<CreateRoomCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var room = RoomModel.CreateRoomModel(Guid.NewGuid(), request.Name, request.Capacity, request.Location);
        
        await roomRepository.AddAsync(room, cancellationToken);

        await roomRepository.SaveChangesAsync(cancellationToken);
        
        return Result<Guid>.Success(room.Id);
    }
}