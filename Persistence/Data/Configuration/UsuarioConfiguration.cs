

using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.Property(e => e.Nombre)
        .HasMaxLength(40)
        .IsRequired();

        builder.Property(e => e.Password)
        .HasMaxLength(225)
        .IsRequired();

        builder.Property(e => e.Email)
        .IsRequired()
        .HasMaxLength(60);

        builder.HasMany(e => e.Roles)
        .WithMany(e => e.Usuarios)
        .UsingEntity<UsuarioRol>(
            j => j.HasOne(e => e.Rol)
            .WithMany(e => e.UsuarioRols)
            .HasForeignKey(e => e.IdRolFK),
            j => j.HasOne(e => e.Usuario)
            .WithMany(e => e.UsuarioRols)
            .HasForeignKey(e => e.IdUsuarioFK),
            j =>
            {
                j.HasKey(e => new { e.IdUsuarioFK, e.IdRolFK });
            }
        );
    }
}