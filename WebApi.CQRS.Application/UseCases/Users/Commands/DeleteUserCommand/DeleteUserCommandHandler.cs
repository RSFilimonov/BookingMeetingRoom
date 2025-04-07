using MediatR;
using WebApi.CQRS.Application.Errors;
using WebApi.CQRS.Common;
using WebApi.CQRS.Domain.Repositories;

namespace WebApi.CQRS.Application.UseCases.Users.Commands;

public class DeleteUserCommandHandler(IUserRepository userRepository) : IRequestHandler<DeleteUserCommand, Result>
{
    public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user is null)
            return Result.Failure(UserErrors.UserNotFoundById(request.UserId.ToString()));
        
        await userRepository.DeleteAsync(user, cancellationToken);
        
        await userRepository.SaveChangesAsync(cancellationToken);
        
        return Result.Success();
    }
}