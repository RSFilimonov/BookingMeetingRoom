using WebApi.CQRS.Domain.Models;

namespace WebApi.CQRS.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с сущностями бронирования
/// </summary>
public interface IBookingRepository
{
    /// <summary>
    /// Получить бронь по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор брони</param>
    /// <returns>Бронь или null, если не найдена</returns>
    Task<BookingModel?> GetByIdAsync(Guid id);
    
    /// <summary>
    /// Получить все будущие брони для указанной комнаты
    /// </summary>
    /// <param name="roomId">Идентификатор комнаты</param>
    /// <returns>Список будущих бронирований</returns>
    Task<IEnumerable<BookingModel>> GetFutureBookingsByRoomAsync(Guid roomId);
    
    /// <summary>
    /// Добавить новую бронь
    /// </summary>
    /// <param name="booking">Экземпляр бронирования</param>
    Task AddAsync(BookingModel booking);
    
    /// <summary>
    /// Удалить бронь
    /// </summary>
    /// <param name="booking">Экземпляр бронирования</param>
    Task DeleteAsync(BookingModel booking);
    
    /// <summary>
    /// Сохранить изменения в хранилище.
    /// </summary>
    Task SaveChangesAsync();
}