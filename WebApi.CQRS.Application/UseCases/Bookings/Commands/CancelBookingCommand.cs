using System.ComponentModel.DataAnnotations;
using MediatR;

namespace WebApi.CQRS.Application.UseCases.Bookings.Commands;

/// <summary>
/// Отменить бронь
/// </summary>
/// <param name="bookingId">Id отменяемой брони</param>
/// <returns>Результат успешности операции</returns>
public class CancelBookingCommand(Guid bookingId) : IRequest<bool>
{
    [Required]
    public Guid BookingId { get; init; }  = bookingId;
}