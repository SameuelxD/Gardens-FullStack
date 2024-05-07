using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class UserRolConfiguration : IEntityTypeConfiguration<UserRol>
    {
        public void Configure(EntityTypeBuilder<UserRol> builder)
        {
            builder.ToTable("userrol");

            builder.HasKey(ur => new { ur.UsuarioId, ur.RolId });

            builder
                .HasOne(ur => ur.Usuario)
                .WithMany(u => u.UsersRols)
                .HasForeignKey(ur => ur.UsuarioId);

            builder.HasOne(ur => ur.Rol).WithMany(r => r.UsersRols).HasForeignKey(ur => ur.RolId);
        }
    }
}
