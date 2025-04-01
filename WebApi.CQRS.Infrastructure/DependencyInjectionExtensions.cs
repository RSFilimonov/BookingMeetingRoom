using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApi.CQRS.Infrastructure.DataAccess;

namespace WebApi.CQRS.Infrastructure;

public static class DependencyInjectionExtensions
{
    public static void UseInfrastructureServices(this IHost app)
    {
        app.ApplyMigrations();
    }

    /// <summary>
    /// Применение текущих миграций к БД
    /// </summary>
    /// <param name="app"></param>
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