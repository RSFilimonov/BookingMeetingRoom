using MediatR;
using WebApi.CQRS.Application.Models;
using WebApi.CQRS.Common;
using WebApi.CQRS.Domain.Enums;
using WebApi.CQRS.Domain.Repositories;

namespace WebApi.CQRS.Application.UseCases.Rooms.Queries;

public class GetAvailableRoomsQueryHandler(IRoomRepository roomRepository, IBookingRepository bookingRepository) : IRequestHandler<GetAvailableRoomsQuery, Result<List<RoomDto>>>
{
    public async Task<Result<List<RoomDto>>> Handle(GetAvailableRoomsQuery request, CancellationToken cancellationToken)
    {
        var allRooms = await roomRepository.GetAllAsync(cancellationToken);

        if (request.MinCapacity.HasValue)
        {
            allRooms = allRooms.Where(room => room.Capacity >= request.MinCapacity.Value);
        }

        var busyRoomIds =
            (await bookingRepository.GetBookingsInRangeAsync(request.StartTime, request.EndTime, cancellationToken))
            .Where(booking => booking.Status == BookingStatus.Confirmed || booking.Status == BookingStatus.Pending)
            .Select(booking => booking.RoomId)
            .Distinct()
            .ToHashSet();

        var availableRooms = allRooms
            .Where(room => !busyRoomIds.Contains(room.Id))
            .Select(room => new RoomDto(room)).ToList();

        return Result<List<RoomDto>>.Success(availableRooms);
    }
}