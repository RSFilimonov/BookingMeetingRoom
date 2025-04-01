using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.CQRS.Domain.Models;

namespace WebApi.CQRS.Infrastructure.DataAccess.EntityTypeConfigurations;

public class BookingEntityTypeConfiguration : IEntityTypeConfiguration<BookingModel>
{
    public void Configure(EntityTypeBuilder<BookingModel> builder)
    {
        builder.HasKey(booking => booking.Id);

        builder.HasOne(booking => booking.User)
            .WithMany(user => user.Bookings)
            .HasForeignKey(booking => booking.UserId);

        builder.HasOne(booking => booking.Room)
            .WithMany(room => room.Bookings)
            .HasForeignKey(booking => booking.RoomId);
    }
}