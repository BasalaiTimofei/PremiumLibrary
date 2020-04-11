using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PremiumLibrary.Models.DataBaseModels;

namespace PremiumLibrary.Context
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(w => w.Id);

            builder.HasMany(w => w.Roles)
                .WithOne(w => w.User);

            builder.Property(w => w.EmailAddress).IsRequired().HasMaxLength(50);
            builder.Property(w => w.Password).IsRequired().IsRequired().HasMaxLength(50);
            builder.Property(w => w.UserName).IsRequired().HasMaxLength(20);
        }
    }

    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(w => w.Id);

            builder.HasMany(w => w.Users)
                .WithOne(w => w.Role);

            builder.Property(w => w.Name).IsRequired().HasMaxLength(20);
        }
    }

    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(w => w.Id);

            builder.HasOne(w => w.User)
                .WithMany(w => w.Roles)
                .HasForeignKey(w => w.UserId);
            builder.HasOne(w => w.Role)
                .WithMany(w => w.Users)
                .HasForeignKey(w => w.RoleId);
        }
    }

}