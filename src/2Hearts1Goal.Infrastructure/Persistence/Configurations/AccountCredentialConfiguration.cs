using _2Hearts1Goal.Modules.Accounts.Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _2Hearts1Goal.Infrastructure.Persistence.Configurations;

public sealed class AccountCredentialConfiguration : IEntityTypeConfiguration<AccountCredentialRecord>
{
    public void Configure(EntityTypeBuilder<AccountCredentialRecord> builder)
    {
        builder.ToTable("Accounts");

        builder.HasKey(account => account.AccountId);

        builder.Property(account => account.Email)
            .HasMaxLength(320)
            .IsRequired();

        builder.Property(account => account.PasswordHash)
            .HasMaxLength(512)
            .IsRequired();

        builder.Property(account => account.PasswordSalt)
            .HasMaxLength(256)
            .IsRequired();

        builder.HasIndex(account => account.Email)
            .IsUnique();
    }
}
