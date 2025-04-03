using MediatR;
using WebApi.CQRS.Application.Models;
using WebApi.CQRS.Common.ValidationAttributes;

namespace WebApi.CQRS.Application.UseCases.Rooms.Queries;

/// <summary>
/// Получить свободные переговорные комнаты на заданный интервал времени
/// </summary>
/// <param name="startTime">Начало интервала времени</param>
/// <param name="endTime">Конец интервала времени</param>
/// <returns>Список свободных переговорных комнат</returns>
public class GetAvailableRoomsQuery(DateTime startTime, DateTime endTime) : IRequest<List<RoomDto>>
{
    [FutureDate]
    public DateTime StartTime { get; init; } = startTime;
    
    [DateGreaterThan(nameof(StartTime))]
    public DateTime EndTime { get; init; } = endTime;
}