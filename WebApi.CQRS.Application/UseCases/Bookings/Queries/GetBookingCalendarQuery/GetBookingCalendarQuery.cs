using System.ComponentModel.DataAnnotations;
using MediatR;
using WebApi.CQRS.Application.Models;
using WebApi.CQRS.Common;
using WebApi.CQRS.Common.ValidationAttributes;

namespace WebApi.CQRS.Application.UseCases.Bookings.Queries;

/// <summary>
/// Вернуть брони в виде событий
/// </summary>
/// <remarks>Для календаря</remarks>
/// <returns>Брони в виде событий</returns>
public class GetBookingCalendarQuery(Guid? userId, DateTime from, DateTime to, Guid? roomId) :  IRequest<Result<List<BookingCalendarItemDto>>>
{
    public Guid? UserId { get; init; } = userId;

    [FutureDate]
    public DateTime From { get; init; } = from;

    [DateGreaterThan(nameof(From))]
    public DateTime To { get; init; } = to;

    public Guid? RoomId { get; init; } = roomId;
}