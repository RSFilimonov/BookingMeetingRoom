using System.ComponentModel.DataAnnotations;
using MediatR;
using WebApi.CQRS.Common.ValidationAttributes;
using WebApi.CQRS.Domain.Enums;

namespace WebApi.CQRS.Application.UseCases.Bookings.Commands;

/// <summary>
/// Создать новую бронь
/// </summary>
/// <param name="roomId">Id переговорной комнаты, которую бронируют</param>
/// <param name="userId">Id пользователя, создающего бронь</param>
/// <param name="startTime">Начало брони</param>
/// <param name="endTime">Конец брони</param>
/// <returns>Id созданного пользователя</returns>
public class CreateBookingCommand(
    Guid roomId,
    Guid userId,
    DateTime startTime,
    DateTime endTime) : IRequest<Guid>
{
    [Required]
    public Guid RoomId { get; init; } = roomId;

    [Required]
    public Guid UserId { get; init; } = userId;

    [FutureDate]
    public DateTime StartTime { get; init; } = startTime;

    [DateGreaterThan(nameof(StartTime))]
    public DateTime EndTime { get; init; } = endTime;
}