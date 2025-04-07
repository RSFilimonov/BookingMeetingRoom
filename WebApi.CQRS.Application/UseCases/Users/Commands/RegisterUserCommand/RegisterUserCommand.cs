using System.ComponentModel.DataAnnotations;
using MediatR;
using WebApi.CQRS.Common;

namespace WebApi.CQRS.Application.UseCases.Users.Commands;

/// <summary>
/// Зарегистрировать нового пользователя в системе
/// </summary>
/// <param name="fullName">Полное имя пользователя</param>
/// <param name="email">Email пользователя</param>
/// <param name="department">Название отдела</param>
/// <returns>Id зарегистрированного пользователя</returns>
public class RegisterUserCommand(string fullName, string email, string? department) : IRequest<Result<Guid>>
{
    [Required]
    public string FullName { get; init; } = fullName;
    [EmailAddress]
    public string Email { get; init; } = email;
    public string? Department { get; init; } = department;
}