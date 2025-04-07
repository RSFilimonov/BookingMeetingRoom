using WebApi.CQRS.Domain.Models;

namespace WebApi.CQRS.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с сущностями бронирования
/// </summary>
public interface IBookingRepository
{
    #region Create
    /// <summary>
    /// Добавить новую бронь
    /// </summary>
    /// <param name="booking">Экземпляр бронирования</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    Task AddAsync(BookingModel booking, CancellationToken cancellationToken);
    #endregion

    #region Read
    /// <summary>
    /// Получить бронь по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор брони</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    /// <returns>Бронь или null, если не найдена</returns>
    Task<BookingModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Получить все будущие брони для указанной комнаты
    /// </summary>
    /// <param name="roomId">Идентификатор комнаты</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    /// <returns>Список будущих бронирований</returns>
    Task<IEnumerable<BookingModel>> GetBookingsByRoomAsync(Guid roomId, CancellationToken cancellationToken);

    /// <summary>
    /// Получить все будущие брони для указанной комнаты
    /// </summary>
    /// <param name="userId">Идентификатор комнаты</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    /// <returns>Список будущих бронирований</returns>
    Task<IEnumerable<BookingModel>> GetBookingsByUserAsync(Guid userId, CancellationToken cancellationToken);

    /// <summary>
    /// Получить список всех истекших броней
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции</param>
    /// <returns>Список всех истекших броней</returns>
    Task<IEnumerable<BookingModel>> GetExpiredBookingsAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Получить список всех броней в заданном промежутке времени
    /// </summary>
    /// <param name="from">От</param>
    /// <param name="to">До</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    /// <returns>Список всех истекших броней</returns>
    Task<IEnumerable<BookingModel>> GetBookingsInRangeAsync(DateTime from, DateTime to, CancellationToken cancellationToken);
    #endregion

    #region Update
    /// <summary>
    /// Обновить данные брони
    /// </summary>
    /// <param name="booking">Экземпляр бронирования</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    /// <returns>Список будущих бронирований</returns>
    Task UpdateAsync(BookingModel booking, CancellationToken cancellationToken);
    #endregion

    #region Delete
    /// <summary>
    /// Удалить бронь
    /// </summary>
    /// <param name="booking">Экземпляр бронирования</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    Task DeleteAsync(BookingModel booking, CancellationToken cancellationToken);
    #endregion

    /// <summary>
    /// Сохранить изменения в хранилище.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции</param>
    Task SaveChangesAsync(CancellationToken cancellationToken);
}