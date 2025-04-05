using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebApi.CQRS.Common.ValidationAttributes;
using WebApi.CQRS.Domain.Enums;

namespace WebApi.CQRS.Domain.Models;

/// <summary>
/// Модель бронирования
/// </summary>
public class BookingModel
{
    /// <summary>
    /// Конструктор модели бронирования
    /// </summary>
    /// <param name="id">Уникальный идентификатор брони</param>
    /// <param name="roomId">Идентификатор комнаты, которую бронируют</param>
    /// <param name="userId">Идентификатор пользователя, забронировавшего комнату</param>
    /// <param name="startTime">Время начала бронирования</param>
    /// <param name="endTime">Время окончания бронирования</param>
    /// <param name="status">Статус бронирования</param>
    private BookingModel(Guid id, Guid roomId, Guid userId, DateTime startTime, DateTime endTime, BookingStatus status)
    {
        Id = id;
        RoomId = roomId;
        UserId = userId;
        StartTime = startTime;
        EndTime = endTime;
        Status = status;
    }

    /// <summary>
    /// Метод создания экземпляра модели бронирования
    /// </summary>
    /// <param name="id">Уникальный идентификатор брони</param>
    /// <param name="roomId">Идентификатор комнаты, которую бронируют</param>
    /// <param name="userId">Идентификатор пользователя, забронировавшего комнату</param>
    /// <param name="startTime">Время начала бронирования</param>
    /// <param name="endTime">Время окончания бронирования</param>
    /// <param name="status">Статус бронирования</param>
    /// <returns>Экземпляр модели бронирования</returns>
    /// <exception cref="ValidationException">Модель не прошла валидацию с заданными параметрами</exception>
    public static BookingModel CreateBookingModel(Guid id, Guid roomId, Guid userId, DateTime startTime, DateTime endTime, BookingStatus status)
    {
        BookingModel model = new BookingModel(id, roomId, userId, startTime, endTime, status);
        ValidationContext context = new ValidationContext(model);
        List<ValidationResult> results = new List<ValidationResult>();
        StringBuilder errors = new StringBuilder();

        if (startTime < DateTime.Now)
            errors.AppendLine("Field \"StartTime\" is required. Start time can't be earlier than now DateTime");
        
        if (!Validator.TryValidateObject(model, context, results, true))
        {
            foreach (var error in results)
            {
                errors.AppendLine(error.ErrorMessage);
            }
        }
        
        if (errors.Length > 0)
            throw new ValidationException(errors.ToString());

        return model;
    }

    /// <summary>
    /// Уникальный идентификатор брони
    /// </summary>
    [Required]
    public Guid Id { get; set; }

    /// <summary>
    /// Идентификатор комнаты, которую бронируют
    /// </summary>
    [Required]
    public Guid RoomId { get; set; }

    /// <summary>
    /// Идентификатор пользователя, забронировавшего комнату
    /// </summary>
    [Required]
    public Guid UserId { get; set; }

    /// <summary>
    /// Время начала бронирования
    /// </summary>
    [Required]
    public DateTime StartTime { get; set; }

    /// <summary>
    /// Время окончания бронирования
    /// </summary>
    [Required]
    [DateGreaterThan(nameof(StartTime))]
    public DateTime EndTime { get; set; }

    /// <summary>
    /// Текущий статус бронирования
    /// </summary>
    [Range(1, 4)]
    public BookingStatus Status { get; set; }

    /// <summary>
    /// Навигационное свойство забронированной комнаты для переговоров
    /// </summary>
    [ForeignKey(nameof(RoomId))]
    public RoomModel Room { get; set; } = null!;

    /// <summary>
    /// Навигационное свойство для пользователя
    /// </summary>
    [ForeignKey(nameof(UserId))]
    public UserModel User { get; set; } = null!;
}
