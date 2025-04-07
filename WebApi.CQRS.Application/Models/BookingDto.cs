using WebApi.CQRS.Domain.Enums;
using WebApi.CQRS.Domain.Models;

namespace WebApi.CQRS.Application.Models;

/// <summary>
/// Data transfer object для возвращения данных о брони
/// </summary>
public record BookingDto
{
    /// <summary>
    /// Data transfer object для возвращения данных о брони
    /// </summary>
    /// <param name="booking">Сущность брони</param>
    public BookingDto(BookingModel booking)
    {
        Id = booking.Id;
        RoomId = booking.RoomId;
        UserId = booking.UserId;
        StartTime = booking.StartTime;
        EndTime = booking.EndTime;
        Status = booking.Status;
    }

    /// <summary>Id брони</summary>
    public Guid Id { get; init; }

    /// <summary>Id забронированной комнаты</summary>
    public Guid RoomId { get; init; }

    /// <summary>Id пользователя забронировавшего комнату</summary>
    public Guid UserId { get; init; }

    /// <summary>Начало прони</summary>
    public DateTime StartTime { get; init; }

    /// <summary>Конец брони</summary>
    public DateTime EndTime { get; init; }

    /// <summary>Статус брони</summary>
    public BookingStatus Status { get; init; }
}