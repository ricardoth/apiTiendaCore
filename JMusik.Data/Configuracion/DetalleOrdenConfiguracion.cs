using JMusik.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JMusik.Data.Configuracion
{
    public class DetalleOrdenConfiguracion : IEntityTypeConfiguration<DetalleOrden>
    {
        public void Configure(EntityTypeBuilder<DetalleOrden> entity)
        {
            entity.ToTable("DetalleOrden", "tienda");

            entity.HasIndex(e => e.OrdenId);

            entity.HasIndex(e => e.ProductoId);

            entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Orden)
                .WithMany(p => p.DetalleOrden)
                .HasForeignKey(d => d.OrdenId);

            entity.HasOne(d => d.Producto)
                .WithMany(p => p.DetalleOrden)
                .HasForeignKey(d => d.ProductoId);
        }
    }
}
