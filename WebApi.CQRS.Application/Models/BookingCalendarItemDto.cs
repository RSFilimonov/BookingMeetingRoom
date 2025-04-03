namespace WebApi.CQRS.Application.Models;

/// <summary>
/// Data transfer object для отображения событий в UI-календаре
/// </summary>
/// <param name="Id">Идентификатор брони./// </param>
/// <param name="RoomName">Название переговорной./// </param>
/// <param name="UserFullName">Имя сотрудника, кто забронировал./// </param>
/// <param name="StartTime">Дата и время начала события./// </param>
/// <param name="EndTime">Дата и время окончания события./// </param>
/// <param name="Status">Статус (например, Confirmed, Cancelled)./// </param>
public record BookingCalendarItemDto(
    Guid Id,
    string RoomName,
    string UserFullName,
    DateTime StartTime,
    DateTime EndTime,
    string Status);