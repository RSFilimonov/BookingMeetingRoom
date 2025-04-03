using MediatR;
using WebApi.CQRS.Application.Models;

namespace WebApi.CQRS.Application.UseCases.Bookings.Queries;

/// <summary>
/// Все будущие брони
/// </summary>
/// <remarks>На неделю, сегодня и т.п.</remarks>
/// <returns>Список будущих броней</returns>
public class GetUpcomingBookingsQuery : IRequest<List<BookingDto>>;