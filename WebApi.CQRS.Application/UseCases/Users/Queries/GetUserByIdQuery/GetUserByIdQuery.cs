using MediatR;
using WebApi.CQRS.Application.Models;
using WebApi.CQRS.Common;

namespace WebApi.CQRS.Application.UseCases.Users.Queries;

/// <summary>
/// Получить данные о пользователе по id
/// </summary>
/// <param name="userId">Id пользователя</param>
/// <returns>Данные о запрошенном пользователе</returns>
public class GetUserByIdQuery(Guid userId) : IRequest<Result<UserDto>>
{
    public Guid UserId { get; init; } =  userId;
}