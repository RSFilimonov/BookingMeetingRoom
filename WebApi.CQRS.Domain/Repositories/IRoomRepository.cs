using WebApi.CQRS.Domain.Models;

namespace WebApi.CQRS.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с переговорными комнатами
/// </summary>
public interface IRoomModelRepository
{
    /// <summary>
    /// Получить комнату по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор комнаты</param>
    /// <returns>Комната или null, если не найдена</returns>
    Task<RoomModel?> GetByIdAsync(Guid id);

    /// <summary>
    /// Получить список всех комнат
    /// </summary>
    /// <returns>Список переговорных комнат</returns>
    Task<IEnumerable<RoomModel>> GetAllAsync();

    /// <summary>
    /// Добавить новую комнату
    /// </summary>
    /// <param name="room">Экземпляр комнаты</param>
    Task AddAsync(RoomModel room);

    /// <summary>
    /// Удалить комнату
    /// </summary>
    /// <param name="room">Экземпляр комнаты</param>
    Task DeleteAsync(RoomModel room);

    /// <summary>
    /// Сохранить изменения в хранилище
    /// </summary>
    Task SaveChangesAsync();
}