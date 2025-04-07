using System.ComponentModel.DataAnnotations;
using MediatR;
using WebApi.CQRS.Application.Models;
using WebApi.CQRS.Common;

namespace WebApi.CQRS.Application.UseCases.Bookings.Queries;

/// <summary>
/// Все брони по комнате	
/// </summary>
/// <param name="roomId">Id переговорной комнаты, брони которой запрашиваются</param>
/// <returns>Брони заданной комнаты</returns>
public class GetBookingsByRoomQuery(Guid roomId) : IRequest<Result<List<BookingDto>>>
{
    [Required]
    public Guid RoomId { get; init; } = roomId;
}