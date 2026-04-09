using _2Hearts1Goal.Modules.Accounts.Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _2Hearts1Goal.Infrastructure.Persistence.Configurations;

public sealed class SessionConfiguration : IEntityTypeConfiguration<SessionRecord>
{
    public void Configure(EntityTypeBuilder<SessionRecord> builder)
    {
        builder.ToTable("AccountSessions");

        builder.HasKey(session => session.SessionToken);

        builder.Property(session => session.IssuedUtc).IsRequired();
        builder.Property(session => session.ExpiresUtc).IsRequired();

        builder.HasIndex(session => session.AccountId);

        builder.HasOne<AccountCredentialRecord>()
            .WithMany()
            .HasForeignKey(session => session.AccountId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
