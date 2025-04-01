using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.CQRS.Domain.Models;

namespace WebApi.CQRS.Infrastructure.DataAccess.EntityTypeConfigurations;

public class RoomEntityTypeConfiguration : IEntityTypeConfiguration<RoomModel>
{
    public void Configure(EntityTypeBuilder<RoomModel> builder)
    {
        builder.HasKey(room => room.Id);

        builder.HasMany(room => room.Bookings)
            .WithOne(booking => booking.Room)
            .HasForeignKey(room => room.RoomId);

        builder.Property(room => room.Name).HasMaxLength(50);
        builder.Property(room => room.Location).HasMaxLength(100);
    }
}