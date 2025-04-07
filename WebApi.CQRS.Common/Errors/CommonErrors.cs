using System.Net;
using WebApi.CQRS.Common.Resources;

namespace WebApi.CQRS.Common.Errors;

public static class CommonErrors
{
    public static Error InternalServerError =>
        new(HttpStatusCode.InternalServerError, ErrorMessages.InternalServerError);
    public static Error ValidationFailed(string? errorMessage) =>
        new(HttpStatusCode.BadRequest, errorMessage ?? ErrorMessages.ValidationFailed);
}