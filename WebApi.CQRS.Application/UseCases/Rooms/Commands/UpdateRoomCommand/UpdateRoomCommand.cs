using System.ComponentModel.DataAnnotations;
using MediatR;
using WebApi.CQRS.Common;

namespace WebApi.CQRS.Application.UseCases.Rooms.Commands;

/// <summary>
/// Обновление полей переговорной комнаты
/// </summary>
/// <param name="roomId">Id переговорной комнаты</param>
/// <param name="name">Название комнаты</param>
/// <param name="capacity">Вместимость переговорной комнаты</param>
/// <param name="location">Адрес переговорной комнаты</param>
/// <returns>Результат успешности операции</returns>
public class UpdateRoomCommand(Guid roomId, string? name, int? capacity, string? location) : IRequest<Result>
{
    [Required]
    public Guid RoomId { get; init; } = roomId;
    
    public string? Name { get; init; } = name;
    
    public int? Capacity { get; init; } = capacity;
    
    public string? Location { get; init; } = location;
}