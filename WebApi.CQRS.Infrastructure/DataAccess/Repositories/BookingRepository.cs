using Microsoft.EntityFrameworkCore;
using WebApi.CQRS.Domain.Enums;
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

    public async Task<IEnumerable<BookingModel>> GetBookingsByRoomAsync(Guid roomId, CancellationToken cancellationToken)
    {
        return await context.Bookings.AsNoTracking()
            .Where(booking => booking.RoomId == roomId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<BookingModel>> GetBookingsByUserAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await context.Bookings.AsNoTracking()
            .Where(booking => booking.UserId == userId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<BookingModel>> GetExpiredBookingsAsync(CancellationToken  cancellationToken)
    {
        var now = DateTime.UtcNow;

        return await context.Bookings.AsNoTracking()
            .Where(b => b.EndTime < now && b.Status == BookingStatus.Confirmed)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<BookingModel>> GetBookingsInRangeAsync(DateTime from, DateTime to, CancellationToken cancellationToken)
    {
        return await context.Bookings.AsNoTracking()
            .Include(b => b.Room)
            .Include(b => b.User)
            .Where(b => b.StartTime < to && b.EndTime > from) // пересекаются с интервалом
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