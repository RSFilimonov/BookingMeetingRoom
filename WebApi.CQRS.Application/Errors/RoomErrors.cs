using System.Net;
using WebApi.CQRS.Common.Errors;
using WebApi.CQRS.Common.Resources;

namespace WebApi.CQRS.Application.Errors;

public static class RoomErrors
{
    public static Error RoomNotFound(string roomId) =>
        new(HttpStatusCode.NotFound, String.Format(ErrorMessages.BookingNotFound, roomId));
}