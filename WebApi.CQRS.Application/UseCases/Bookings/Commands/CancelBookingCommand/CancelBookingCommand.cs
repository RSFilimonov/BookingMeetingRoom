using System.ComponentModel.DataAnnotations;
using MediatR;
using WebApi.CQRS.Common;

namespace WebApi.CQRS.Application.UseCases.Bookings.Commands;

/// <summary>
/// Отменить бронь
/// </summary>
/// <param name="bookingId">Id отменяемой брони</param>
/// <returns>Результат успешности операции</returns>
public class CancelBookingCommand(Guid bookingId) : IRequest<Result>
{
    [Required]
    public Guid BookingId { get; init; }  = bookingId;
}