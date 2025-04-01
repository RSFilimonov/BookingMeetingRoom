using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.CQRS.Domain.Models;

namespace WebApi.CQRS.Infrastructure.DataAccess.EntityTypeConfigurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        builder.HasKey(user => user.Id);

        builder.HasMany(user => user.Bookings)
            .WithOne(booking => booking.User)
            .HasForeignKey(user => user.UserId);

        builder.Property(user => user.FullName).HasMaxLength(100);
        builder.Property(user => user.Department).HasMaxLength(100);
    }
}