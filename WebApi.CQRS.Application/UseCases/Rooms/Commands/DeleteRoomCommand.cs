using System.ComponentModel.DataAnnotations;
using MediatR;

namespace WebApi.CQRS.Application.UseCases.Rooms.Commands;

/// <summary>
/// Удаление переговорной комнаты
/// </summary>
/// <param name="roomId">Id комнаты</param>
/// <returns>Результат успешности операции</returns>
public class DeleteRoomCommand(Guid roomId) : IRequest<bool>
{
    [Required]
    public Guid RoomId { get; init; } = roomId;
}