using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.CQRS.Infrastructure.DataAccess;

namespace WebApi.CQRS.Infrastructure.Extensions;

public static class PersistenceExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MeetingRoomDb");

        if (string.IsNullOrWhiteSpace(connectionString))
            throw new InvalidOperationException("Connection string was not provided.");

        services
            .AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

        return services;
    }
}