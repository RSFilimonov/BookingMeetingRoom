using Microsoft.EntityFrameworkCore;
using WebApi.CQRS.Domain.Models;
using WebApi.CQRS.Domain.Repositories;

namespace WebApi.CQRS.Infrastructure.DataAccess.Repositories;

public class UserRepository(AppDbContext context) : IUserModelRepository
{
    #region Create
    public Task AddAsync(UserModel user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        // Не используем AddAsync потому что этот вид метода имеет смысл только при использовании баз данных, которые
        // поддерживают асинхронные операции с IDENTITY/AUTOINCREMENT (например, SQL Server, PostgreSQL).
        // В данной ситуации PK задается вручную, и работает так же, как Add.
        context.Users.Add(user);

        return Task.CompletedTask;
    }
    #endregion

    #region Read
    public async Task<UserModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        if (id  == Guid.Empty)
            throw new ArgumentException(nameof(id));
        
        return await context.Users.FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
    }

    public async Task<UserModel?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(email))
            throw new ArgumentNullException(nameof(email));
        
        return await context.Users.FirstOrDefaultAsync(user => user.Email == email, cancellationToken);
    }

    public async Task<IEnumerable<UserModel>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.Users.ToListAsync(cancellationToken);
    }
    #endregion

    #region Update
    public Task UpdateAsync(UserModel user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        context.Users.Update(user);
        
        return Task.CompletedTask;
    }
    #endregion

    #region Delete
    public Task DeleteAsync(UserModel user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        context.Users.Remove(user);

        return Task.CompletedTask;
    }
    #endregion

    public async Task SaveChangesAsync(CancellationToken cancellationToken){
        await context.SaveChangesAsync(cancellationToken);
    }
}
