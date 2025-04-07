using System.ComponentModel.DataAnnotations;
using MediatR;
using WebApi.CQRS.Application.Models;
using WebApi.CQRS.Common;

namespace WebApi.CQRS.Application.UseCases.Rooms.Queries;

/// <summary>
/// Получить данные о переговорной комнате по id
/// </summary>
/// <param name="roomId">Id переговорной комнаты</param>
/// <returns>Данные о переговорной комнате</returns>
public class GetRoomByIdQuery(Guid roomId) : IRequest<Result<RoomDto>>
{
    [Required]
    public Guid RoomId { get; init; } = roomId;
}