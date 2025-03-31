using WebApi.CQRS.Domain.Models;

namespace WebApi.CQRS.Domain.Repositories;

/// <summary>
/// Репозиторий для управления пользователями
/// </summary>
public interface IUserModelRepository
{
    /// <summary>
    /// Получить пользователя по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор пользователя</param>
    /// <returns>Пользователь или null, если не найден</returns>
    Task<UserModel?> GetByIdAsync(Guid id);

    /// <summary>
    /// Получить пользователя по email
    /// </summary>
    /// <param name="email">Email пользователя</param>
    /// <returns>Пользователь или null, если не найден</returns>
    Task<UserModel?> GetByEmailAsync(string email);

    /// <summary>
    /// Получить всех пользователей
    /// </summary>
    /// <returns>Список пользователей</returns>
    Task<IEnumerable<UserModel>> GetAllAsync();

    /// <summary>
    /// Добавить нового пользователя
    /// </summary>
    /// <param name="user">Экземпляр пользователя</param>
    Task AddAsync(UserModel user);

    /// <summary>
    /// Удалить пользователя
    /// </summary>
    /// <param name="user">Экземпляр пользователя</param>
    Task DeleteAsync(UserModel user);

    /// <summary>
    /// Сохранить изменения в хранилище
    /// </summary>
    Task SaveChangesAsync();
}