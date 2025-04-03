using System.ComponentModel.DataAnnotations;
using MediatR;

namespace WebApi.CQRS.Application.UseCases.Users.Commands;

/// <summary>
/// Удалить пользователя
/// </summary>
/// <param name="userId">Id удаляемого пользователя</param>
/// <returns>Результат успешности операции</returns>
public class DeleteUserCommand(Guid userId) : IRequest<bool>
{
    [Required]
    public Guid UserId { get; init; } = userId;
}