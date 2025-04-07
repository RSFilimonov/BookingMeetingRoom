using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.Extensions.Logging;
using WebApi.CQRS.Common;
using WebApi.CQRS.Common.Errors;
using WebApi.CQRS.Domain.Models;
using WebApi.CQRS.Domain.Repositories;

namespace WebApi.CQRS.Application.UseCases.Users.Commands;

public class RegisterUserCommandHandler(IUserRepository userRepository, ILogger<RegisterUserCommandHandler> logger)
    : IRequestHandler<RegisterUserCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = UserModel.CreateUserModel(Guid.NewGuid(), request.FullName, request.Email, request.Department);

            await userRepository.AddAsync(user, cancellationToken);
            await userRepository.SaveChangesAsync(cancellationToken);

            return Result<Guid>.Success(user.Id);
        }
        catch (ValidationException ex)
        {
            return Result<Guid>.Failure(CommonErrors.ValidationFailed(ex.Message));
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return Result<Guid>.Failure(CommonErrors.InternalServerError);
        }
    }
}