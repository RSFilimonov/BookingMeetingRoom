namespace WebApi.CQRS.Domain.External;

public interface IExternalUserProvider
{
    /// <summary>
    /// Получить список пользователей из внешнего источника.
    /// </summary>
    Task<IEnumerable<ExternalUserDto>> GetUsersAsync(string sourceName);
}