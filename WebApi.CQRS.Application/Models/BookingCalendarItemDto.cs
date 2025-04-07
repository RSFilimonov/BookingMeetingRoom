using WebApi.CQRS.Domain.Models;

namespace WebApi.CQRS.Application.Models;

/// <summary>
/// Data transfer object для отображения событий в UI-календаре
/// </summary>
public record BookingCalendarItemDto
{
    /// <summary>
    /// Data transfer object для отображения событий в UI-календаре
    /// </summary>
    /// <param name="booking">Экземпляр брони </param>
    public BookingCalendarItemDto(BookingModel booking)
    {
        Id = booking.Id;
        RoomName = booking.Room.Name;
        UserFullName = booking.User.FullName;
        StartTime = booking.StartTime;
        EndTime = booking.EndTime;
        Status = booking.Status.ToString();
    }

    /// <summary>Идентификатор брони./// </summary>
    public Guid Id { get; init; }

    /// <summary>Название переговорной./// </summary>
    public string RoomName { get; init; }

    /// <summary>Имя сотрудника, кто забронировал./// </summary>
    public string UserFullName { get; init; }

    /// <summary>Дата и время начала события./// </summary>
    public DateTime StartTime { get; init; }

    /// <summary>Дата и время окончания события./// </summary>
    public DateTime EndTime { get; init; }

    /// <summary>Статус (например, Confirmed, Cancelled)./// </summary>
    public string Status { get; init; }
}