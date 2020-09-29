using JMusik.Data.Contratos;
using JMusik.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JMusik.Data.Repositorios
{
    public class RepositorioPerfiles : IRepositorioGenerico<Perfil>
    {
        private readonly TiendaDbContext _contexto;
        private readonly ILogger<RepositorioPerfiles> _logger;
        private DbSet<Perfil> _dbSet;

        public RepositorioPerfiles(TiendaDbContext contexto, ILogger<RepositorioPerfiles> logger)
        {
            this._contexto = contexto;
            this._logger = logger;
            this._dbSet = _contexto.Set<Perfil>();
        }
        public async Task<bool> Actualizar(Perfil entity)
        {
            _dbSet.Attach(entity);
            _contexto.Entry(entity).State = EntityState.Modified;
            try
            {
                return await _contexto.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception excepcion)
            {
                _logger.LogError($"Error en {nameof(Actualizar)}: " + excepcion.Message);
            }
            return false;
        }

        public async Task<Perfil> Agregar(Perfil entity)
        {
            _dbSet.Add(entity);
            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch (Exception excepcion)
            {
                _logger.LogError($"Error en {nameof(Agregar)}: " + excepcion.Message);
                return null;
            }
            return entity;
        }

        public async Task<bool> Eliminar(int id)
        {
            var entity = await _dbSet.SingleOrDefaultAsync(u => u.Id == id);
            _dbSet.Remove(entity);
            try
            {
                return (await _contexto.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception excepcion)
            {
                _logger.LogError($"Error en {nameof(Eliminar)}: " + excepcion.Message);
            }
            return false;
        }

        public async Task<Perfil> ObtenerAsync(int id)
        {
            return await _dbSet.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Perfil>> ObtenerTodosAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
