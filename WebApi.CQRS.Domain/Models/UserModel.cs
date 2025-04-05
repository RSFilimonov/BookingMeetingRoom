using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApi.CQRS.Domain.Models;

/// <summary>
/// Модель пользователя
/// </summary>
public class UserModel
{
    /// <summary>
    /// Конструктор модели прользователя
    /// </summary>
    /// <param name="id">Уникальный идентификатор пользователя</param>
    /// <param name="fullName">Полное имя пользователя</param>
    /// <param name="email">Email пользователя</param>
    /// <param name="department">Название отдела</param>
    private UserModel(Guid id, string fullName, string email, string? department)
    {
        Id = id;
        FullName = fullName;
        Email = email;
        Department = department;
    }

    /// <summary>
    /// Метод создания экземпляра модели пользователя
    /// </summary>
    /// <param name="id">Уникальный идентификатор пользователя</param>
    /// <param name="fullName">Полное имя пользователя</param>
    /// <param name="email">Email пользователя</param>
    /// <param name="department">Название отдела</param>
    /// <returns>Экземпляр модели пользователя</returns>
    /// <exception cref="ValidationException">Модель не прошла валидацию с заданными параметрами</exception>
    public static UserModel CreateUserModel(Guid id, string fullName, string email, string? department)
    {
        UserModel model = new UserModel(id, fullName, email, department);
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
    /// Уникальный идентификатор пользователя
    /// </summary>
    [Required]
    public Guid Id { get; set; }

    /// <summary>
    /// Полное имя пользователя (ФИО)
    /// </summary>
    [Required]
    [StringLength(100)]
    public string FullName { get; set; }

    /// <summary>
    /// Email пользователя (используется для уведомлений и входа)
    /// </summary>
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    /// <summary>
    /// Название отдела (опционально)
    /// </summary>
    [StringLength(100)]
    public string? Department { get; set; }

    /// <summary>
    /// Список всех бронирований пользователя
    /// </summary>
    public ICollection<BookingModel> Bookings { get; set; } = null!;
}