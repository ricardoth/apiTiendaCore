using JMusik.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JMusik.Data.Configuracion
{
    public class OrdenConfiguracion : IEntityTypeConfiguration<Orden>
    {
        public void Configure(EntityTypeBuilder<Orden> entity)
        {
            entity.ToTable("Orden", "tienda");

            entity.HasIndex(e => e.UsuarioId);

            entity.Property(e => e.CantidadArticulos).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.Importe).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Usuario)
                .WithMany(p => p.Orden)
                .HasForeignKey(d => d.UsuarioId);
        }
    }
}
