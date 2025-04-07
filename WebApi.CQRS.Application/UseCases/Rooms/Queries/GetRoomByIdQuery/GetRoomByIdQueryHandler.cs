using MediatR;
using WebApi.CQRS.Application.Errors;
using WebApi.CQRS.Application.Models;
using WebApi.CQRS.Common;
using WebApi.CQRS.Domain.Repositories;

namespace WebApi.CQRS.Application.UseCases.Rooms.Queries;

public class GetRoomByIdQueryHandler(IRoomRepository roomRepository) : IRequestHandler<GetRoomByIdQuery, Result<RoomDto>>
{
    public async Task<Result<RoomDto>> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
    {
        var room = await roomRepository.GetByIdAsync(request.RoomId, cancellationToken);
        
        if (room is null)
            return Result<RoomDto>.Failure(RoomErrors.RoomNotFound(request.RoomId.ToString()));
        
        return Result<RoomDto>.Success(new RoomDto(room));
    }
}