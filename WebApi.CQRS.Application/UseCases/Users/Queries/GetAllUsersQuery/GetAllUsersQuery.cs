using MediatR;
using WebApi.CQRS.Application.Models;
using WebApi.CQRS.Common;

namespace WebApi.CQRS.Application.UseCases.Users.Queries;

/// <summary>
/// Получить данные о всех пользователях
/// </summary>
/// <returns>Список всех пользователей</returns>
public class GetAllUsersQuery : IRequest<Result<List<UserDto>>>;