using System.ComponentModel.DataAnnotations;
using MediatR;
using WebApi.CQRS.Common;

namespace WebApi.CQRS.Application.UseCases.Users.Commands;

/// <summary>
/// Удалить пользователя
/// </summary>
/// <param name="userId">Id удаляемого пользователя</param>
/// <returns>Результат успешности операции</returns>
public class DeleteUserCommand(Guid userId) : IRequest<Result>
{
    [Required]
    public Guid UserId { get; init; } = userId;
}