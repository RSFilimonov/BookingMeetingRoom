using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.Extensions.Logging;
using WebApi.CQRS.Common;
using WebApi.CQRS.Common.Errors;
using WebApi.CQRS.Domain.Enums;
using WebApi.CQRS.Domain.Models;
using WebApi.CQRS.Domain.Repositories;

namespace WebApi.CQRS.Application.UseCases.Bookings.Commands;

/// <summary>
/// Обработчик команды создания брони
/// </summary>
/// <param name="bookingRepository">Репозиторий для работы с сущностями бронирования</param>
public class CreateBookingCommandHandler(IBookingRepository bookingRepository, ILogger logger)
    : IRequestHandler<CreateBookingCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        try
        {
            BookingModel newBooking = BookingModel.CreateBookingModel(
                Guid.NewGuid(),
                request.RoomId,
                request.UserId,
                request.StartTime,
                request.EndTime,
                BookingStatus.Pending);

            await bookingRepository.AddAsync(newBooking, cancellationToken);
            await bookingRepository.SaveChangesAsync(cancellationToken);

            return Result<Guid>.Success(newBooking.Id);
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