using System.Net;
using Newtonsoft.Json;

namespace WebApi.CQRS.Common.Errors;

[method: JsonConstructor]
public readonly record struct Error(HttpStatusCode RelatedStatusCode, string Description)
{
    /// <summary>
    /// Описание ошибки.
    /// </summary>
    [JsonProperty]
    public string Description { get; } = Description;

    /// <summary>
    /// Связанный с ошибкой код статуса ответа
    /// </summary>
    [JsonProperty]
    public HttpStatusCode RelatedStatusCode { get; } = RelatedStatusCode;

    /// <summary>
    /// Перегрузка метода ToString()
    /// </summary>
    /// <returns><see cref="Description"/></returns>
    public override string ToString() => Description;
}