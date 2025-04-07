using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using WebApi.CQRS.Domain.Repositories;
using WebApi.CQRS.Infrastructure.DataAccess;
using WebApi.CQRS.Infrastructure.DataAccess.Repositories;
using WebApi.CQRS.Infrastructure.Quartz.Jobs;

namespace WebApi.CQRS.Infrastructure;

public static class DependencyInjectionExtensions
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services);
        AddQuartz(services);
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
        services.AddTransient<IUserModelRepository, UserRepository>();
        services.AddTransient<IRoomRepository, RoomRepository>();
        services.AddTransient<IBookingRepository, BookingRepository>();
        
        return services;
    }
    
    /// <summary>
    /// Регистрация Quartz в DI
    /// </summary>
    private static IServiceCollection AddQuartz(this IServiceCollection services)
    {
        services.AddQuartz(q =>
        {
            // Регистрируем джоб
            var jobKey = new JobKey("ExpireBookingsJob");
            q.AddJob<ExpireBookingsJob>(opts => opts.WithIdentity(jobKey));

            // Триггер с расписанием (каждые 5 минут)
            q.AddTrigger(opts => opts
                .ForJob(jobKey)
                .WithIdentity("ExpireBookingsJob-trigger")
                .WithCronSchedule("0 */5 * * * ?")); // каждые 5 мин
        });

        services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
        
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