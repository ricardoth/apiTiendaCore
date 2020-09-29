using JMusik.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JMusik.Data.Contratos
{
    public interface IOrdenesRepositorio : IRepositorioGenerico<Orden>
    {
        Task<IEnumerable<Orden>> ObtenerTodosConDetallesAsync();
        Task<Orden> ObtenerConDetallesAsync(int id);
    }
}
