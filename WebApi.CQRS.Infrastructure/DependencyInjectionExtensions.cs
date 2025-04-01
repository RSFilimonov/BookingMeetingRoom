using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApi.CQRS.Domain.Repositories;
using WebApi.CQRS.Infrastructure.DataAccess;
using WebApi.CQRS.Infrastructure.DataAccess.Repositories;

namespace WebApi.CQRS.Infrastructure;

public static class DependencyInjectionExtensions
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services);
    }
    public static void UseInfrastructureServices(this IHost app)
    {
        app.ApplyMigrations();
    }
    
    /// <summary>
    /// Регистрация репозиториев в DI
    /// </summary>
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUserModelRepository, UserModelRepository>();
        services.AddTransient<IRoomModelRepository, RoomModelRepository>();
        services.AddTransient<IBookingRepository, BookingRepository>();
        
        return services;
    }

    /// <summary>
    /// Применение текущих миграций к БД
    /// </summary>
    private static void ApplyMigrations(this IHost app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        if (dbContext.Database.IsRelational())
        {
            dbContext.Database.Migrate();
        }
    }
}