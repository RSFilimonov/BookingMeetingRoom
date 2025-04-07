using MediatR;
using WebApi.CQRS.Application.Models;
using WebApi.CQRS.Common;
using WebApi.CQRS.Domain.Repositories;

namespace WebApi.CQRS.Application.UseCases.Bookings.Queries;

public class GetBookingCalendarQueryHandler(IBookingRepository bookingRepository) : IRequestHandler<GetBookingCalendarQuery, Result<List<BookingCalendarItemDto>>>
{
    public async Task<Result<List<BookingCalendarItemDto>>> Handle(GetBookingCalendarQuery request, CancellationToken cancellationToken)
    {
        var bookings = await bookingRepository.GetBookingsInRangeAsync(request.From, request.To, cancellationToken);

        if (request.RoomId.HasValue)
            bookings = bookings.Where(b => b.RoomId == request.RoomId.Value);

        if (request.UserId.HasValue)
            bookings = bookings.Where(b => b.UserId == request.UserId.Value);

        return Result<List<BookingCalendarItemDto>>.Success(
            bookings.Select(booking => new BookingCalendarItemDto(booking)).ToList());
    }
}