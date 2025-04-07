using MediatR;
using WebApi.CQRS.Application.Errors;
using WebApi.CQRS.Common;
using WebApi.CQRS.Domain.Enums;
using WebApi.CQRS.Domain.Repositories;

namespace WebApi.CQRS.Application.UseCases.Bookings.Commands;

public class ExpireBookingCommandHandler(IBookingRepository bookingRepository) : IRequestHandler<ExpireBookingCommand, Result>
{
    public async Task<Result> Handle(ExpireBookingCommand request, CancellationToken cancellationToken)
    {
        var booking = await bookingRepository.GetByIdAsync(request.BookingId, cancellationToken);

        if (booking is null)
            return Result.Failure(BookingErrors.BookingNotFound(request.BookingId.ToString()));

        if (booking.Status is BookingStatus.Expired or BookingStatus.Cancelled)
            return Result.Failure(BookingErrors.BookingIsCancelledOrExpired(request.BookingId.ToString()));

        if (booking.Status == BookingStatus.Confirmed && booking.EndTime < DateTime.UtcNow)
        {
            booking.Status = BookingStatus.Expired;

            await bookingRepository.UpdateAsync(booking, cancellationToken);
            await bookingRepository.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }

        // Бронь уже не активна или не истекла
        return Result.Failure(BookingErrors.BookingIsNoActiveOrNoExpired(request.BookingId.ToString())); 
    }
}