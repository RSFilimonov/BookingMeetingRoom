namespace WebApi.CQRS.Application.Models;

/// <summary>
/// Data transfer object для возвращения данных о переговорной комнате
/// </summary>
/// <param name="Id">Id переговорной комнаты</param>
/// <param name="Name">Название переговорной комнаты</param>
/// <param name="Capacity">Вместимость переговорной комнаты</param>
/// <param name="Location">Адрес переговорной комнаты</param>
public record RoomDto(Guid Id, string Name, int Capacity, string Location);