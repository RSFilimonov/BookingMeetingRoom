using MediatR;
using WebApi.CQRS.Application.Models;
using WebApi.CQRS.Common;
using WebApi.CQRS.Domain.Enums;
using WebApi.CQRS.Domain.Repositories;

namespace WebApi.CQRS.Application.UseCases.Bookings.Queries;

public class GetUpcomingBookingsQueryHandler(IBookingRepository bookingRepository) : IRequestHandler<GetUpcomingBookingsQuery, Result<List<BookingDto>>>
{
    public async Task<Result<List<BookingDto>>> Handle(GetUpcomingBookingsQuery request, CancellationToken cancellationToken)
    {
        var from = DateTime.UtcNow;
        var to = request.Until;

        var bookings = await bookingRepository.GetBookingsInRangeAsync(from, to, cancellationToken);

        if (request.UserId.HasValue)
            bookings = bookings.Where(b => b.UserId == request.UserId.Value);

        if (request.RoomId.HasValue)
            bookings = bookings.Where(b => b.RoomId == request.RoomId.Value);

        return Result<List<BookingDto>>.Success(
            bookings
                .Where(booking => booking.Status == BookingStatus.Confirmed || booking.Status == BookingStatus.Pending)
                .OrderBy(b => b.StartTime)
                .Select(booking => new BookingDto(booking)).ToList());
    }
}