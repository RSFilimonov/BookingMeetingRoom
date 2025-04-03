using System.ComponentModel.DataAnnotations;
using MediatR;

namespace WebApi.CQRS.Application.UseCases.Rooms.Commands;

/// <summary>
/// Создать новую переговорную комнату
/// </summary>
/// <param name="name">Название комнаты</param>
/// <param name="capacity">Вместимость переговорной комнаты</param>
/// <param name="location">Адрес переговорной комнаты</param>
/// <returns>Id созданной комнаты</returns>
public class CreateRoomCommand(string name, int capacity, string location) : IRequest<Guid>
{
    [Required]
    public string Name { get; init; } = name;
    
    [Length(1, 100)]
    public int Capacity { get; init; } = capacity;
    
    [Required]
    public string Location { get; init; } = location;
}