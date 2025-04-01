using Microsoft.EntityFrameworkCore;
using WebApi.CQRS.Domain.Models;
using WebApi.CQRS.Infrastructure.DataAccess.EntityTypeConfigurations;

namespace WebApi.CQRS.Infrastructure.DataAccess;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
        
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<BookingModel> Bookings { get; set; } = null!;
    public DbSet<RoomModel> Rooms { get; set; } = null!;
    public DbSet<UserModel> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(RoomEntityTypeConfiguration).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(BookingEntityTypeConfiguration).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(UserEntityTypeConfiguration).Assembly);

        base.OnModelCreating(builder);
    }
}