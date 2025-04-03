namespace WebApi.CQRS.Application.Models;

/// <summary>
/// Data transfer object 
/// </summary>
/// <param name="Id">Уникальный идентификатор пользователя</param>
/// <param name="FullName">Полное имя пользователя</param>
/// <param name="Email">Email пользователя</param>
/// <param name="Department">Название отдела</param>
public record UserDto(Guid Id, string FullName, string Email, string? Department);