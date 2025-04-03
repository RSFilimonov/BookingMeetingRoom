using System.ComponentModel.DataAnnotations;
using MediatR;
using WebApi.CQRS.Application.Models;

namespace WebApi.CQRS.Application.UseCases.Users.Queries;

/// <summary>
/// Получить данные о пользователе по email
/// </summary>
/// <param name="email">Email пользователя</param>
/// <returns>Данные о запрошенном пользователе</returns>
public class GetUserByEmailQuery(string email) : IRequest<UserDto>
{
    [Required]
    public string Email { get; init; } = email;
}