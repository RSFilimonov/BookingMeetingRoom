using System.Net;
using System.Text.Json.Serialization;
using WebApi.CQRS.Common.Errors;

namespace WebApi.CQRS.Common;

/// <summary>
/// Generic Result
/// </summary>
public sealed record Result<T>
{
    /// <summary>
    /// Значение хранимое объектом
    /// </summary>
    public T Value { get; }
    
    /// <summary>
    /// Флаг, указывающий на успешность результата
    /// </summary>
    public bool Succeeded { get; }

    /// <summary>
    /// Статус-код результата
    /// </summary>
    public HttpStatusCode StatusCode { get; }
    
    /// <summary>
    /// Ошибка, если имеется
    /// </summary>
    public Error Error { get; }
    
    [JsonConstructor]
    private Result(T value, bool succeeded, HttpStatusCode statusCode, Error error = default)
    {
        Succeeded = succeeded;
        Value = value;
        Error = error;
        StatusCode = statusCode;
    }

    public static Result<T> Success(T value, HttpStatusCode statusCode = HttpStatusCode.OK)
        => new(value, true, statusCode);

    public static Result<T> Failure(Error error)
        => new(default!, false, error.RelatedStatusCode, error);
}

/// <summary>
/// Not generic Result
/// </summary>
public sealed record Result
{
    /// <summary>
    /// Флаг, указывающий на успешность результата
    /// </summary>
    public bool Succeeded { get; }

    /// <summary>
    /// Статус-код результата
    /// </summary>
    public HttpStatusCode StatusCode { get; }
    
    /// <summary>
    /// Ошибка, если имеется
    /// </summary>
    public Error Error { get; }
    
    [JsonConstructor]
    private Result(bool succeeded, HttpStatusCode statusCode, Error error = default)
    {
        Succeeded = succeeded;
        Error = error;
        StatusCode = statusCode;
    }

    public static Result Success(HttpStatusCode statusCode = HttpStatusCode.OK)
        => new(true, statusCode);

    public static Result Failure(Error error)
        => new(false, error.RelatedStatusCode, error);
}