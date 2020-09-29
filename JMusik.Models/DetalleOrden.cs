using System;
using System.Collections.Generic;

namespace JMusik.Models
{
    public class DetalleOrden
    {
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Total { get; set; }

        public virtual Orden Orden { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
