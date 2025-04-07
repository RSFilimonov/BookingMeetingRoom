using MediatR;
using Microsoft.Extensions.Logging;
using WebApi.CQRS.Common;
using WebApi.CQRS.Domain.External;
using WebApi.CQRS.Domain.Models;
using WebApi.CQRS.Domain.Repositories;

namespace WebApi.CQRS.Application.UseCases.Users.Commands;

public class SyncExternalUsersCommandHandler(
    IExternalUserProvider externalUserProvider,
    IUserRepository userRepository,
    ILogger<SyncExternalUsersCommand> logger) : IRequestHandler<SyncExternalUsersCommand, Result<int>>
{
    public async Task<Result<int>> Handle(SyncExternalUsersCommand request, CancellationToken cancellationToken)
    {
        var externalUsers = await externalUserProvider.GetUsersAsync(request.Source);
        int synced = 0;

        foreach (var extUser in externalUsers)
        {
            var existing = await userRepository.GetByEmailAsync(extUser.Email, cancellationToken);

            if (existing == null)
            {
                try
                {
                    var newUser = UserModel.CreateUserModel(Guid.NewGuid(), extUser.FullName, extUser.Email, extUser.Department);

                    await userRepository.AddAsync(newUser, cancellationToken);

                    synced++;
                }
                catch (Exception exception)
                {
                    logger.LogError(exception, exception.Message);
                }
            }
            else
            {
                existing.FullName = extUser.FullName;
                existing.Department = extUser.Department;
                synced++;
            }
            
        }

        await userRepository.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Синхронизировано пользователей: {Count}", synced);
        
        return Result<int>.Success(synced);
    }
}