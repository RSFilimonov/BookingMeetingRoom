using WebApi.CQRS.Domain.Models;

namespace WebApi.CQRS.Application.Models;

/// <summary>
/// Data transfer object 
/// </summary>
public record UserDto
{
    /// <summary>
    /// Data transfer object 
    /// </summary>
    /// <param name="user">Экземпляр класса модели пользователя</param>
    public UserDto(UserModel user)
    {
        Id = user.Id;
        FullName = user.FullName;
        Email = user.Email;
        Department = user.Department;
    }

    /// <summary>Уникальный идентификатор пользователя</summary>
    public Guid Id { get; init; }

    /// <summary>Полное имя пользователя</summary>
    public string FullName { get; init; }

    /// <summary>Email пользователя</summary>
    public string Email { get; init; }

    /// <summary>Название отдела</summary>
    public string? Department { get; init; }
}