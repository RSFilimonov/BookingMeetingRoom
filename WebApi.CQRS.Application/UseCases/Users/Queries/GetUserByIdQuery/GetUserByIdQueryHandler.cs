using MediatR;
using WebApi.CQRS.Application.Errors;
using WebApi.CQRS.Application.Models;
using WebApi.CQRS.Common;
using WebApi.CQRS.Domain.Repositories;

namespace WebApi.CQRS.Application.UseCases.Users.Queries;

public class GetUserByIdQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserByIdQuery, Result<UserDto>> 
{
    public async Task<Result<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.UserId, cancellationToken);
        
        if (user is null)
            return Result<UserDto>.Failure(UserErrors.UserNotFoundById(request.UserId.ToString()));
        
        return Result<UserDto>.Success(new UserDto(user));
    }
}