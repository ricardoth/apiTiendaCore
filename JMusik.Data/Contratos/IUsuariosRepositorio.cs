using JMusik.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JMusik.Data.Contratos
{
    public interface IUsuariosRepositorio : IRepositorioGenerico<Usuario>
    {
        Task<bool> CambiarContrasena(Usuario usuario);
        Task<bool> CambiarPerfil(Usuario usuario);
        Task<bool> ValidarContrasena(Usuario usuario);
        Task<(bool resultado, Usuario usuario)> ValidarDatosLogin(Usuario datosLoginUsuario);
    }
}
