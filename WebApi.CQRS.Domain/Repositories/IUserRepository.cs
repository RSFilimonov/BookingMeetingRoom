using WebApi.CQRS.Domain.Models;

namespace WebApi.CQRS.Domain.Repositories;

/// <summary>
/// Репозиторий для управления пользователями
/// </summary>
public interface IUserRepository
{
    #region Create
    /// <summary>
    /// Добавить нового пользователя
    /// </summary>
    /// <param name="user">Экземпляр пользователя</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    Task AddAsync(UserModel user, CancellationToken cancellationToken);
    #endregion

    #region Read
    /// <summary>
    /// Получить пользователя по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор пользователя</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    /// <returns>Пользователь или null, если не найден</returns>
    Task<UserModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Получить пользователя по email
    /// </summary>
    /// <param name="email">Email пользователя</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    /// <returns>Пользователь или null, если не найден</returns>
    Task<UserModel?> GetByEmailAsync(string email, CancellationToken cancellationToken);

    /// <summary>
    /// Получить всех пользователей
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции</param>
    /// <returns>Список пользователей</returns>
    Task<IEnumerable<UserModel>> GetAllAsync(CancellationToken cancellationToken);
    #endregion

    #region Update
    /// <summary>
    /// Обновить данные пользователя
    /// </summary>
    /// <param name="user">Экземпляр пользователя</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    Task UpdateAsync(UserModel user, CancellationToken cancellationToken);
    #endregion

    #region Delete
    /// <summary>
    /// Удалить пользователя
    /// </summary>
    /// <param name="user">Экземпляр пользователя</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    Task DeleteAsync(UserModel user, CancellationToken cancellationToken);
    #endregion

    /// <summary>
    /// Сохранить изменения в хранилище
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции</param>
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
