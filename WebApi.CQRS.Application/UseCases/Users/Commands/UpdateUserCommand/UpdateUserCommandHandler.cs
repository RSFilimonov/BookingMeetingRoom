using MediatR;
using WebApi.CQRS.Application.Errors;
using WebApi.CQRS.Common;
using WebApi.CQRS.Domain.Repositories;

namespace WebApi.CQRS.Application.UseCases.Users.Commands;

public class UpdateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<UpdateUserCommand, Result>
{
    public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user is null)
            return Result.Failure(UserErrors.UserNotFoundById(request.UserId.ToString()));

        if (request.FullName is not null)
            user.FullName = request.FullName;

        if (request.Email is not null)
            user.Email = request.Email;

        if (request.Department is not null)
            user.Department = request.Department;

        await userRepository.UpdateAsync(user, cancellationToken);

        await userRepository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}