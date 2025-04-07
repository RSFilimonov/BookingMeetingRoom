using MediatR;
using WebApi.CQRS.Application.Models;
using WebApi.CQRS.Common;
using WebApi.CQRS.Domain.Repositories;

namespace WebApi.CQRS.Application.UseCases.Rooms.Queries;

public class GetAllRoomsQueryHandler(IRoomRepository roomRepository) : IRequestHandler<GetAllRoomsQuery, Result<List<RoomDto>>>
{
    public async Task<Result<List<RoomDto>>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
    {
        var rooms = await roomRepository.GetAllAsync(cancellationToken);
        
        return Result<List<RoomDto>>.Success(rooms.Select(room => new RoomDto(room)).ToList());
    }
}