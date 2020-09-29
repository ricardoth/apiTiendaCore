using JMusik.Models;
using JMusik.Models.Enum;
using System;
using System.Collections.Generic;

namespace JMusik.Models
{
    public class Producto
    {
        public Producto()
        {
            DetalleOrden = new HashSet<DetalleOrden>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public EstatusProducto Estatus { get; set; }
        public DateTime FechaRegistro { get; set; }

        public virtual ICollection<DetalleOrden> DetalleOrden { get; set; }
    }
}
