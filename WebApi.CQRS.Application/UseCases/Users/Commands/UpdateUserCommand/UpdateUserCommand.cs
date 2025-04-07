using System.ComponentModel.DataAnnotations;
using MediatR;
using WebApi.CQRS.Common;

namespace WebApi.CQRS.Application.UseCases.Users.Commands;

/// <summary>
/// Обновить данные пользователя
/// </summary>
/// <param name="userId">Id пользователя, данные которого обновляются</param>
/// <param name="fullName">Полное имя пользователя</param>
/// <param name="email">Email пользователя</param>
/// <param name="department">Название отдела</param>
/// <returns>Результат успешности операции</returns>
public class UpdateUserCommand(Guid userId, string? fullName, string? email, string? department) : IRequest<Result>
{
    [Required]
    public Guid UserId { get; } = userId;
    public string? FullName { get; } = fullName;
    public string? Email { get; } = email;
    public string? Department { get; } = department;
}