using MediatR;
using WebApi.CQRS.Application.Models;
using WebApi.CQRS.Common;
using WebApi.CQRS.Domain.Repositories;

namespace WebApi.CQRS.Application.UseCases.Bookings.Queries;

public class GetBookingsByRoomQueryHandler(IBookingRepository bookingRepository) : IRequestHandler<GetBookingsByRoomQuery, Result<List<BookingDto>>>
{
    public async Task<Result<List<BookingDto>>> Handle(GetBookingsByRoomQuery request, CancellationToken cancellationToken)
    {
        var bookings = await bookingRepository.GetBookingsByRoomAsync(request.RoomId, cancellationToken);
        
        return Result<List<BookingDto>>.Success(bookings.Select(booking => new BookingDto(booking)).ToList());
    }
}