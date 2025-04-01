using Microsoft.EntityFrameworkCore;
using WebApi.CQRS.Domain.Models;
using WebApi.CQRS.Domain.Repositories;

namespace WebApi.CQRS.Infrastructure.DataAccess.Repositories;

public class RoomModelRepository(AppDbContext context) :  IRoomModelRepository
{
    #region Create
    public Task AddAsync(RoomModel room, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        context.Rooms.Add(room);

        return Task.CompletedTask;
    }
    #endregion

    #region Read
    public async Task<RoomModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Rooms.FirstOrDefaultAsync(room =>  room.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<RoomModel>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.Rooms.ToListAsync(cancellationToken);
    }
    #endregion

    #region Update
    public Task UpdateAsync(RoomModel room, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        context.Rooms.Update(room);
        
        return Task.CompletedTask;
    }
    #endregion

    #region Delete
    public Task DeleteAsync(RoomModel room, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        context.Rooms.Remove(room);
        
        return Task.CompletedTask;
    }
    #endregion

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}