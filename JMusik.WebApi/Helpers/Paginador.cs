using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMusik.WebApi.Helpers
{
    public class Paginador<T> where T : class
    {
        public int PaginaActual { get; set; }
        public int RegistrosPorPagina { get; set; }
        public int TotalRegistros { get; set; }
        public IEnumerable<T> Registros { get; set; }

        public Paginador(IEnumerable<T> registros, int totalRegistros, int paginaActual, int registrosPorPagina)
        {
            Registros = registros;
            TotalRegistros = totalRegistros;
            PaginaActual = paginaActual;
            RegistrosPorPagina = registrosPorPagina;
        }

        public int TotalPaginas
        {
            get
            {
                return (int)Math.Ceiling(TotalRegistros / (double)RegistrosPorPagina);
            }
        }

        public bool TienePaginaAnterior 
        {
            get
            {
                return (PaginaActual > 1);
            }
        }

        public bool TienePaginaSiguiente
        {
            get 
            {
                return (PaginaActual < TotalPaginas);
            }
        }
    }
}
