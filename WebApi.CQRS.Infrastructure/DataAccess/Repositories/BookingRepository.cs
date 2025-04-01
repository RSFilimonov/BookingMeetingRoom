using Microsoft.EntityFrameworkCore;
using WebApi.CQRS.Domain.Models;
using WebApi.CQRS.Domain.Repositories;

namespace WebApi.CQRS.Infrastructure.DataAccess.Repositories;

public class BookingRepository(AppDbContext context) : IBookingRepository
{
    #region Create
    public Task AddAsync(BookingModel booking, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        context.Bookings.Add(booking);
        
        return Task.CompletedTask;
    }
    #endregion

    #region Read
    public async Task<BookingModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Bookings.AsNoTracking().FirstOrDefaultAsync(booking => booking.Id == id,  cancellationToken);
    }

    public async Task<IEnumerable<BookingModel>> GetFutureBookingsByRoomAsync(Guid roomId, CancellationToken cancellationToken)
    {
        return await context.Bookings.AsNoTracking()
            .Where(booking => booking.RoomId == roomId && booking.StartTime > DateTime.Now)
            .ToListAsync(cancellationToken);
    }
    #endregion

    #region Update
    public Task UpdateAsync(BookingModel booking, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        context.Bookings.Update(booking);
        
        return Task.CompletedTask;
    }
    #endregion

    #region Delete
    public Task DeleteAsync(BookingModel booking, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        context.Bookings.Remove(booking);
        
        return Task.CompletedTask;
    }
    #endregion

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}