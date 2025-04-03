using MediatR;
using WebApi.CQRS.Application.Models;
using WebApi.CQRS.Common.ValidationAttributes;

namespace WebApi.CQRS.Application.UseCases.Bookings.Queries;

/// <summary>
/// Вернуть брони в виде событий
/// </summary>
/// <remarks>Для календаря</remarks>
/// <returns>Брони в виде событий</returns>
public class GetBookingCalendarQuery(DateTime from, DateTime to, Guid? roomId) :  IRequest<List<BookingCalendarItemDto>>
{
    [FutureDate]
    public DateTime From { get; set; } = from;
    
    [DateGreaterThan(nameof(From))]
    public DateTime To { get; set; } = to;
    
    public Guid? RoomId { get; set; } = roomId;
}