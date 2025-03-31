using System.ComponentModel.DataAnnotations;
using WebApi.CQRS.Common.Resources;

namespace WebApi.CQRS.Common.ValidationAttributes;

/// <summary>
/// Атрибут проверяющий поле типа DateTime на то чтоб занчение в нём не было раньшее чем в указанном в параметре 
/// </summary>
/// <param name="comparisonProperty">Параметр для сравнения</param>
public class DateGreaterThanAttribute(string comparisonProperty) : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var currentValue = (DateTime?)value;

        var property = validationContext.ObjectType.GetProperty(comparisonProperty);
        if (property == null)
            return new ValidationResult(string.Format(ErrorMessages.UnknownProperty, comparisonProperty));

        var comparisonValue = (DateTime?)property.GetValue(validationContext.ObjectInstance);

        if (currentValue.HasValue && comparisonValue.HasValue && currentValue <= comparisonValue)
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}