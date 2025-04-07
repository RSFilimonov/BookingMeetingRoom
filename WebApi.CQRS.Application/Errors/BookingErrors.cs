using System.Net;
using WebApi.CQRS.Common.Errors;
using WebApi.CQRS.Common.Resources;

namespace WebApi.CQRS.Application.Errors;

public static class BookingErrors
{
    public static Error BookingNotFound(string bookingId) =>
        new(HttpStatusCode.NotFound, String.Format(ErrorMessages.BookingNotFound, bookingId));
    
    public static Error BookingIsCancelledOrExpired(string bookingId) =>
        new(HttpStatusCode.Gone, String.Format(ErrorMessages.BookingIsCancelledOrExpired, bookingId));
    
    public static Error BookingIsNoActiveOrNoExpired(string bookingId) =>
        new(HttpStatusCode.BadRequest, String.Format(ErrorMessages.BookingIsNoActiveOrNoExpired, bookingId));
}