using _2Hearts1Goal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _2Hearts1Goal.Infrastructure.Persistence.Configurations;

public sealed class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.ToTable("Profiles");

        builder.HasKey(profile => profile.Id);

        builder.Property(profile => profile.DisplayName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(profile => profile.City)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(profile => profile.StateOrProvince)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(profile => profile.Bio)
            .HasMaxLength(1000);

        builder.OwnsOne(
            profile => profile.MatchPreferences,
            preferences =>
            {
                preferences.Property(p => p.MinimumAge).HasColumnName("PreferredMinimumAge");
                preferences.Property(p => p.MaximumAge).HasColumnName("PreferredMaximumAge");
                preferences.Property(p => p.MaximumDistanceMiles).HasColumnName("PreferredMaximumDistanceMiles");
                preferences.Property(p => p.InterestedIn).HasColumnName("InterestedIn");
                preferences.Property(p => p.Intent).HasColumnName("PreferredIntent");
            });
    }
}
