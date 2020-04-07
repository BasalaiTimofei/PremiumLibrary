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

            builder.Property(w => w.EmailAddress).IsRequired().HasMaxLength(50);
            builder.Property(w => w.Password).IsRequired().IsRequired().HasMaxLength(50);
            builder.Property(w => w.UserName).IsRequired().HasMaxLength(20);
        }
    }
}