using MediatR;
using WebApi.CQRS.Application.Models;
using WebApi.CQRS.Common;

namespace WebApi.CQRS.Application.UseCases.Bookings.Queries;

/// <summary>
/// Все будущие брони
/// </summary>
/// <param name="userId">Id юзера для фильтрации записей</param>
/// <param name="roomId">Id комнаты для фильтрации записей</param>
/// <param name="until">До какого времени (например, +7 дней)</param>
/// <remarks>Если параметр <see cref="Until"/> не задан, то автоматически возвращает на 7 дней</remarks>
/// <returns>Список будущих броней</returns>
public class GetUpcomingBookingsQuery(Guid? userId, Guid? roomId, DateTime? until) : IRequest<Result<List<BookingDto>>>
{
    public Guid? UserId { get; set; } = userId;
    public Guid? RoomId { get; set; } = roomId;
    public DateTime Until { get; set; } = until ?? DateTime.UtcNow.AddDays(7);
}