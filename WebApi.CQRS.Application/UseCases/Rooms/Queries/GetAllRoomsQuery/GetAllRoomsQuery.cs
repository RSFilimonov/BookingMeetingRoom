using MediatR;
using WebApi.CQRS.Application.Models;
using WebApi.CQRS.Common;

namespace WebApi.CQRS.Application.UseCases.Rooms.Queries;

/// <summary>
/// Запрос на получение всех переговорных комнат
/// </summary>
/// <returns>Список всех переговорных комнат</returns>
public class GetAllRoomsQuery : IRequest<Result<List<RoomDto>>>;