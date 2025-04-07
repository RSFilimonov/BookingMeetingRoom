using MediatR;
using WebApi.CQRS.Application.Errors;
using WebApi.CQRS.Application.Models;
using WebApi.CQRS.Common;
using WebApi.CQRS.Domain.Repositories;

namespace WebApi.CQRS.Application.UseCases.Bookings.Queries;

public class GetBookingByIdQueryHandler(IBookingRepository bookingRepository) : IRequestHandler<GetBookingByIdQuery, Result<BookingDto>>
{
    public async Task<Result<BookingDto>> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
    {
        var booking = await bookingRepository.GetByIdAsync(request.BookingId,  cancellationToken);
        
        if (booking is null)
            return Result<BookingDto>.Failure(BookingErrors.BookingNotFound(request.BookingId.ToString()));

        return Result<BookingDto>.Success(new BookingDto(booking));
    }
}