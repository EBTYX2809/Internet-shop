using Internet_shop.Infrastructure.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Internet_shop.Infrastructure.Configurations.UserConfigurations;

internal class RefreshTokenEntityConfiguration : IEntityTypeConfiguration<RefreshTokenEntity>
{
    public void Configure(EntityTypeBuilder<RefreshTokenEntity> builder)
    {
        builder.ToTable("RefreshTokens");

        builder.HasKey(rt => rt.Id);

        builder.Property(rt => rt.Id)
            .IsRequired()
            .ValueGeneratedOnAdd()
            .HasColumnName("id");

        builder.Property(rt => rt.Token)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("token");

        builder.HasIndex(rt => rt.Token).IsUnique();

        builder.Property(rt => rt.ExpiresAt)
            .IsRequired()
            .HasColumnName("expires_at");

        builder.Property(rt => rt.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder.Property(rt => rt.IsRevoked)
            .IsRequired()
            .HasColumnName("is_revoked");

        builder.HasOne(rt => rt.User)
            .WithMany()
            .HasForeignKey(rt => rt.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(rt => rt.UserId)
            .IsRequired()
            .HasColumnName("user_fk");

        builder.HasIndex(rt => rt.UserId);
    }
}
