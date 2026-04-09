using _2Hearts1Goal.Modules.Users.Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _2Hearts1Goal.Infrastructure.Persistence.Configurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<UserRecord>
{
    public void Configure(EntityTypeBuilder<UserRecord> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(user => user.UserId);

        builder.Property(user => user.DisplayName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(user => user.TimeZone)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(user => user.AccountId)
            .IsUnique();

        builder.HasOne<_2Hearts1Goal.Modules.Accounts.Application.Models.AccountCredentialRecord>()
            .WithMany()
            .HasForeignKey(user => user.AccountId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
