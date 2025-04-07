using System.ComponentModel.DataAnnotations;
using MediatR;
using WebApi.CQRS.Common;
using WebApi.CQRS.Common.ValidationAttributes;

namespace WebApi.CQRS.Application.UseCases.Bookings.Commands;

/// <summary>
/// Изменение времени брони
/// </summary>
/// <param name="bookingId">Id брони, время которой изменяют</param>
/// <param name="startTime">Новое время начала брони</param>
/// <param name="endTime">Новое время конца брони</param>
/// <returns>Результат успешности операции</returns>
public class UpdateBookingTimeCommand(Guid bookingId, DateTime startTime, DateTime endTime) : IRequest<Result>
{
    [Required]
    public Guid BookingId { get; init; } =  bookingId;
    
    [FutureDate]
    public DateTime StartTime { get; init; } =  startTime;
    
    [DateGreaterThan(nameof(StartTime))]
    public DateTime EndTime { get; init; } = endTime;
}