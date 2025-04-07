using MediatR;
using WebApi.CQRS.Application.Models;
using WebApi.CQRS.Common;
using WebApi.CQRS.Domain.Repositories;

namespace WebApi.CQRS.Application.UseCases.Bookings.Queries;

public class GetBookingsByUserQueryHandler(IBookingRepository bookingRepository) : IRequestHandler<GetBookingsByUserQuery, Result<List<BookingDto>>>
{
    public async Task<Result<List<BookingDto>>> Handle(GetBookingsByUserQuery request, CancellationToken cancellationToken)
    {
        var bookings = await bookingRepository.GetBookingsByRoomAsync(request.UserId, cancellationToken);
        
        return Result<List<BookingDto>>.Success(bookings.Select(booking => new BookingDto(booking)).ToList());
    }
}