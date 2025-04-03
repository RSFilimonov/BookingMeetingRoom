using WebApi.CQRS.Domain.Enums;
using WebApi.CQRS.Domain.Models;

namespace WebApi.CQRS.Application.Models;

/// <summary>
/// Data transfer object для возвращения данных о брони
/// </summary>
/// <param name="Id">Id брони</param>
/// <param name="RoomId">Id забронированной комнаты</param>
/// <param name="UserId">Id пользователя забронировавшего комнату</param>
/// <param name="StartTime">Начало прони</param>
/// <param name="EndTime">Конец брони</param>
/// <param name="Status">Статус брони</param>
public record BookingDto(Guid Id, Guid RoomId, Guid UserId, DateTime StartTime, DateTime EndTime, BookingStatus Status);