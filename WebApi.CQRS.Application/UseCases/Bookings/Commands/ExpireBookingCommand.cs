using System.ComponentModel.DataAnnotations;
using MediatR;

namespace WebApi.CQRS.Application.UseCases.Bookings.Commands;

/// <summary>
/// Просрочить бронь
/// </summary>
/// <remarks>Используется Quartz.Net</remarks>
/// <param name="bookingId">Id просроченной брони</param>
/// <returns>Результат успешности операции</returns>
public class ExpireBookingCommand(Guid bookingId) : IRequest<bool>
{
    [Required]
    public Guid BookingId { get; init; } = bookingId;
}