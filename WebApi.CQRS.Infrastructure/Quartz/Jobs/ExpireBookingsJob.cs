using MediatR;
using Quartz;
using WebApi.CQRS.Application.UseCases.Bookings.Commands;
using WebApi.CQRS.Domain.Repositories;

namespace WebApi.CQRS.Infrastructure.Quartz.Jobs;

public class ExpireBookingsJob(IBookingRepository bookingRepository,IMediator mediator) : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        var expiredBookings = await bookingRepository.GetExpiredBookingsAsync(context.CancellationToken);

        foreach (var booking in expiredBookings)
            await mediator.Send(new ExpireBookingCommand(booking.Id));
    }
}