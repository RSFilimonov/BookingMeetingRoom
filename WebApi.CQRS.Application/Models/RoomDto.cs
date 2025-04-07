using WebApi.CQRS.Domain.Models;

namespace WebApi.CQRS.Application.Models;

/// <summary>
/// Data transfer object для возвращения данных о переговорной комнате
/// </summary>
public record RoomDto
{
    /// <summary>
    /// Data transfer object для возвращения данных о переговорной комнате
    /// </summary>
    /// <param name="room">Экземпляр модели переговорной комнаты</param>
    public RoomDto(RoomModel room)
    {
        Id = room.Id;
        Name = room.Name;
        Capacity = room.Capacity;
        Location = room.Location;
    }

    public Guid Id { get; init; }

    public string Name { get; init; }

    public int Capacity { get; init; }

    public string Location { get; init; }
}