using System.Net;
using WebApi.CQRS.Common.Errors;
using WebApi.CQRS.Common.Resources;

namespace WebApi.CQRS.Application.Errors;

public static class UserErrors
{
    public static Error UserNotFoundById(string userId) =>
        new(HttpStatusCode.NotFound, String.Format(ErrorMessages.UserNotFoundById, userId));
    public static Error UserNotFoundByEmail(string email) =>
        new(HttpStatusCode.NotFound, String.Format(ErrorMessages.UserNotFoundByEmail, email));
}