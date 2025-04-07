using System.ComponentModel.DataAnnotations;
using MediatR;
using WebApi.CQRS.Common;

namespace WebApi.CQRS.Application.UseCases.Bookings.Commands;

/// <summary>
/// Просрочить бронь
/// </summary>
/// <remarks>Используется Quartz.Net</remarks>
/// <param name="bookingId">Id просроченной брони</param>
/// <returns>Результат успешности операции</returns>
public class ExpireBookingCommand(Guid bookingId) : IRequest<Result>
{
    [Required]
    public Guid BookingId { get; init; } = bookingId;
}