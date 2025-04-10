using System.ComponentModel.DataAnnotations;
using MediatR;
using WebApi.CQRS.Application.Models;
using WebApi.CQRS.Common;

namespace WebApi.CQRS.Application.UseCases.Bookings.Queries;

/// <summary>
/// Все брони конкретного пользователя
/// </summary>
/// <param name="userId">Id пользователя, брони которого запрашиваются</param>
/// <returns>Брони заданного пользователя</returns>
public class GetBookingsByUserQuery(Guid userId) : IRequest<Result<List<BookingDto>>>
{
    [Required]
    public Guid UserId { get; init; } = userId;
}