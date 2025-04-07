using MediatR;
using WebApi.CQRS.Application.Errors;
using WebApi.CQRS.Common;
using WebApi.CQRS.Domain.Enums;
using WebApi.CQRS.Domain.Models;
using WebApi.CQRS.Domain.Repositories;

namespace WebApi.CQRS.Application.UseCases.Bookings.Commands;

public class UpdateBookingTimeCommandHandler(IBookingRepository bookingRepository) : IRequestHandler<UpdateBookingTimeCommand, Result>
{
    public async Task<Result> Handle(UpdateBookingTimeCommand request, CancellationToken cancellationToken)
    {
        BookingModel? booking = await bookingRepository.GetByIdAsync(request.BookingId,  cancellationToken);
        
        if (booking is null)
            return Result.Failure(BookingErrors.BookingNotFound(request.BookingId.ToString()));

        if (booking.Status is BookingStatus.Expired or BookingStatus.Cancelled)
            return Result.Failure(BookingErrors.BookingIsCancelledOrExpired(request.BookingId.ToString()));

        booking.StartTime = request.StartTime;
        booking.EndTime = request.EndTime;

        await bookingRepository.UpdateAsync(booking,  cancellationToken);
        await bookingRepository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}