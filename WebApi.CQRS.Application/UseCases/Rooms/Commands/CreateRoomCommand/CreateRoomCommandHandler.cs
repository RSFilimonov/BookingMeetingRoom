using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.Extensions.Logging;
using WebApi.CQRS.Common;
using WebApi.CQRS.Common.Errors;
using WebApi.CQRS.Domain.Models;
using WebApi.CQRS.Domain.Repositories;

namespace WebApi.CQRS.Application.UseCases.Rooms.Commands;

public class CreateRoomCommandHandler(IRoomRepository roomRepository, ILogger<CreateRoomCommandHandler> logger) : IRequestHandler<CreateRoomCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var room = RoomModel.CreateRoomModel(Guid.NewGuid(), request.Name, request.Capacity, request.Location);

            await roomRepository.AddAsync(room, cancellationToken);

            await roomRepository.SaveChangesAsync(cancellationToken);

            return Result<Guid>.Success(room.Id);
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