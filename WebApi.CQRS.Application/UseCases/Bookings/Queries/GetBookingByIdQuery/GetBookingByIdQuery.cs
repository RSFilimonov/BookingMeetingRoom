using System.ComponentModel.DataAnnotations;
using MediatR;
using WebApi.CQRS.Application.Models;
using WebApi.CQRS.Common;
using WebApi.CQRS.Domain.Models;

namespace WebApi.CQRS.Application.UseCases.Bookings.Queries;

/// <summary>
/// Получить конкретную бронь
/// </summary>
/// <param name="bookingId">Id запрашиваемой брони</param>
/// <returns>Данные брони</returns>
public class GetBookingByIdQuery(Guid bookingId) : IRequest<Result<BookingDto>>
{
    [Required]
    public Guid BookingId { get; init; } = bookingId;
}