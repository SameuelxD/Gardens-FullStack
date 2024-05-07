using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);

            builder.Property(x => x.Username).IsRequired().HasMaxLength(50);

            builder.HasIndex(p => new { p.Username, p.Email })
                   .HasDatabaseName("IX_MiIndice")
                   .IsUnique();

            builder.Property(x => x.Password).IsRequired().HasMaxLength(225);

            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);

            builder.HasMany(u => u.RefreshTokens)
                   .WithOne(rt => rt.User)
                   .HasForeignKey(rt => rt.UserId);
        }
    }
}
