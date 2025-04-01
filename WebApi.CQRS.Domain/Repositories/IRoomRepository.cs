using WebApi.CQRS.Domain.Models;

namespace WebApi.CQRS.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с переговорными комнатами
/// </summary>
public interface IRoomModelRepository
{
    #region Create

    /// <summary>
    /// Добавить новую комнату
    /// </summary>
    /// <param name="room">Экземпляр комнаты</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    Task AddAsync(RoomModel room, CancellationToken cancellationToken);
    #endregion

    #region Read
    /// <summary>
    /// Получить комнату по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор комнаты</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    /// <returns>Комната или null, если не найдена</returns>
    Task<RoomModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Получить список всех комнат
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции</param>
    /// <returns>Список переговорных комнат</returns>
    Task<IEnumerable<RoomModel>> GetAllAsync(CancellationToken cancellationToken);
    #endregion

    #region Update
    /// <summary>
    /// Обновить данные комнаты
    /// </summary>
    /// <param name="room">Экземпляр комнаты</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    Task UpdateAsync(RoomModel room, CancellationToken cancellationToken);
    #endregion

    #region Delete
    /// <summary>
    /// Удалить комнату
    /// </summary>
    /// <param name="room">Экземпляр комнаты</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    Task DeleteAsync(RoomModel room, CancellationToken cancellationToken);
    #endregion

    /// <summary>
    /// Сохранить изменения в хранилище
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции</param>
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
