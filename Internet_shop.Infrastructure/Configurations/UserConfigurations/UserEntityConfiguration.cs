using Internet_shop.Infrastructure.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Internet_shop.Infrastructure.Configurations.UserConfigurations;

internal class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .IsRequired()
            .HasColumnName("id");

        builder.Property(u => u.IsGuest)
            .IsRequired()
            .HasDefaultValue(true)
            .HasColumnName("is_guest");

        builder.HasIndex(u => u.Email).IsUnique();

        builder.Property(u => u.Email)
            .IsRequired(false)
            .HasMaxLength(50)
            .HasColumnName("email");

        builder.HasIndex(u => u.Phone).IsUnique();

        builder.Property(u => u.Phone)
            .IsRequired(false)            
            .HasMaxLength(15)
            .HasColumnName("phone");

        builder.Property(u => u.PasswordHash)
            .IsRequired(false)
            .HasMaxLength(50)
            .HasColumnName("password_hash");

        builder.Property(u => u.Salt)
            .IsRequired(false)
            .HasMaxLength(30)
            .HasColumnName("salt");

        builder.Property(u => u.AddressCountry)
            .IsRequired(false)
            .HasMaxLength(100)
            .HasColumnName("address_country");

        builder.Property(u => u.AddressCity)
            .IsRequired(false)
            .HasMaxLength(100)
            .HasColumnName("address_city");

        builder.Property(u => u.AddressStreet)
            .IsRequired(false)
            .HasMaxLength(100)
            .HasColumnName("address_street");        
    }
}