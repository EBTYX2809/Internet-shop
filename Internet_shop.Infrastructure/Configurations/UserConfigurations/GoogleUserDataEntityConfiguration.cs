using Internet_shop.Infrastructure.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Internet_shop.Infrastructure.Configurations.UserConfigurations;

internal class GoogleUserDataEntityConfiguration : IEntityTypeConfiguration<GoogleUserDataEntity>
{
    public void Configure(EntityTypeBuilder<GoogleUserDataEntity> builder)
    {
        builder.ToTable("GoogleUsersData");

        builder.HasKey(gud => gud.UserId);

        builder.Property(gud => gud.GoogleUserId)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("google_user_id");

        builder.HasOne(gud => gud.User)
            .WithOne()
            .HasForeignKey<GoogleUserDataEntity>(gud => gud.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
