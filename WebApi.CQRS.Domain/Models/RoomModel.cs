using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApi.CQRS.Domain.Models;

/// <summary>
/// Модель комнаты для переговоров
/// </summary>
public class RoomModel
{
    /// <summary>
    /// Конструктор модели комнаты для переговоров
    /// </summary>
    /// <param name="id">Уникальный идентификатор переговорной комнаты</param>
    /// <param name="name">Название комнаты</param>
    /// <param name="capacity">Вместимость комнаты</param>
    /// <param name="location">Местоположение комнаты</param>
    private RoomModel(Guid id, string name, int capacity, string location)
    {
        Id = id;
        Name = name;
        Capacity = capacity;
        Location = location;
    }
    
    /// <summary>
    /// Метод создания экземпляра модели комнаты для переговоров
    /// </summary>
    /// <param name="id">Уникальный идентификатор переговорной комнаты</param>
    /// <param name="name">Название комнаты</param>
    /// <param name="capacity">Вместимость комнаты</param>
    /// <param name="location">Местоположение комнаты</param>
    /// <returns>Экземпляр модели комнаты для переговоров</returns>
    /// <exception cref="ValidationException">Модель не прошла валидацию с заданными параметрами</exception>
    public RoomModel CreateRoomModel(Guid id, string name, int capacity, string location)
    {
        RoomModel model = new RoomModel(id, name, capacity, location);
        ValidationContext context = new ValidationContext(model);
        List<ValidationResult> results = new List<ValidationResult>();
        StringBuilder errors = new StringBuilder();
        
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
    /// Уникальный идентификатор переговорной комнаты
    /// </summary>
    [Required]
    public Guid Id { get; set; }

    /// <summary>
    /// Название комнаты
    /// </summary>
    /// <remarks>До 50 символов</remarks>
    /// <example>"Room A"</example>
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    /// <summary>
    /// Вместимость комнаты
    /// </summary>
    /// <remarks>от 1 до 100 человек</remarks>
    [Range(1, 100)]
    public int Capacity { get; set; }

    /// <summary>
    /// Местоположение комнаты
    /// </summary>
    /// <remarks>До 100 символов</remarks>
    /// <example>"Краснодар, ул. Пушкина, д. 11, этаж 3, офис 310"</example>
    [Required]
    [StringLength(100)]
    public string Location { get; set; }

    public ICollection<BookingModel> Bookings { get; set; } = null!;
}