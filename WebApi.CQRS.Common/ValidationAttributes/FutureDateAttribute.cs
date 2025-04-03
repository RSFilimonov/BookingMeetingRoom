using System.ComponentModel.DataAnnotations;

namespace WebApi.CQRS.Common.ValidationAttributes;

/// <summary>
/// Проверяет, что дата указана не ранее текущего времени (UTC).
/// </summary>
public class FutureDateAttribute : ValidationAttribute
{
    /// <summary>
    /// Переопределяет логику валидации значения.
    /// </summary>
    /// <param name="value">Значение, которое валидируется.</param>
    /// <returns>True, если дата корректна или пустая; иначе false.</returns>
    public override bool IsValid(object? value)
    {
        if (value is DateTime dateTime)
        {
            return dateTime >= DateTime.UtcNow;
        }

        return true;
    }

    /// <summary>
    /// Сообщение по умолчанию (если не задано явно).
    /// </summary>
    public override string FormatErrorMessage(string name)
    {
        return ErrorMessage ?? $"{name} должно быть не раньше текущего времени.";
    }
}