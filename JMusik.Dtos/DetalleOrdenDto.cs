using System;
using System.Collections.Generic;
using System.Text;

namespace JMusik.Dtos
{
    public class DetalleOrdenDto
    {
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public string Producto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Total { get; set; }
    }

}
