
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.Property(e => e.Precio)
        .HasPrecision(15,2)
        .IsRequired();
        builder.Property(e => e.Nombre)
        .HasMaxLength(50)
        .IsRequired();
        builder.Property(e => e.Cantidad)
        .IsRequired();
        builder.HasOne(e => e.Tipo)
        .WithMany(e => e.Productos)
        .HasForeignKey(e => e.IdTipoFk);
    }
}