using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class TipoConfiguration : IEntityTypeConfiguration<Tipo>
{
    public void Configure(EntityTypeBuilder<Tipo> builder)
    {
        builder.Property(e => e.Nombre)
        .HasMaxLength(50)
        .IsRequired();
    }
}