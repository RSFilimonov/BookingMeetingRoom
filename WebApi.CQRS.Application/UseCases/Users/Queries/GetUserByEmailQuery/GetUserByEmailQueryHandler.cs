using MediatR;
using WebApi.CQRS.Application.Errors;
using WebApi.CQRS.Application.Models;
using WebApi.CQRS.Common;
using WebApi.CQRS.Domain.Repositories;

namespace WebApi.CQRS.Application.UseCases.Users.Queries;

public class GetUserByEmailQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserByEmailQuery, Result<UserDto>>
{
    public async Task<Result<UserDto>> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (user is null)
            return Result<UserDto>.Failure(UserErrors.UserNotFoundByEmail(request.Email));

        return Result<UserDto>.Success(new UserDto(user));
    }
}