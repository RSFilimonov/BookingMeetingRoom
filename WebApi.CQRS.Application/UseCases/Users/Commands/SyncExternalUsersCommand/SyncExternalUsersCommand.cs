using System.ComponentModel.DataAnnotations;
using MediatR;
using WebApi.CQRS.Common;

namespace WebApi.CQRS.Application.UseCases.Users.Commands;

/// <summary>
/// Команда для синхронизации пользователей из внешнего источника
/// </summary>
/// <param name="source">Источник данных (например, "ldap", "excel", "api")</param>
/// <returns>Кол-во добавленных пользователей</returns>
public class SyncExternalUsersCommand(string source) : IRequest<Result<int>>
{
    [Required]
    public string Source { get; } = source;
}