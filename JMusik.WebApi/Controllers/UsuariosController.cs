using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JMusik.Data.Contratos;
using JMusik.Dtos;
using JMusik.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JMusik.WebApi.Controllers
{
    [Authorize(Roles = "Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuariosRepositorio _usuariosRepositorio;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuariosRepositorio _usuariosRepositorio, IMapper mapper)
        {
            this._usuariosRepositorio = _usuariosRepositorio;
            this._mapper = mapper;
        }

        //// GET: api/usuarios
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<UsuarioListaDto>>> Get()
        {
            try
            {
                var usuarios = await _usuariosRepositorio.ObtenerTodosAsync();
                return _mapper.Map<List<UsuarioListaDto>>(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: api/usuarios/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UsuarioListaDto>> Get(int id)
        {
            var usuario = await _usuariosRepositorio.ObtenerAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return _mapper.Map<UsuarioListaDto>(usuario);
        }

        // POST: api/usuarios
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UsuarioListaDto>> Post(UsuarioRegistroDto usuarioDto)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(usuarioDto);

                var nuevoUsuario = await _usuariosRepositorio.Agregar(usuario);
                if (nuevoUsuario == null)
                {
                    return BadRequest();
                }

                var nuevoUsuarioDto = _mapper.Map<UsuarioListaDto>(nuevoUsuario);
                return CreatedAtAction(nameof(Post), new { id = nuevoUsuarioDto.Id }, nuevoUsuarioDto);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT: api/usuarios/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UsuarioListaDto>> Put(int id, [FromBody] UsuarioActualizacionDto usuarioDto)
        {
            if (usuarioDto == null)
                return NotFound();

            var usuario = _mapper.Map<Usuario>(usuarioDto);
            var resultado = await _usuariosRepositorio.Actualizar(usuario);
            if (!resultado)
                return BadRequest();

            return _mapper.Map<UsuarioListaDto>(usuario);
        }

        // DELETE: api/usuarios/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var resultado = await _usuariosRepositorio.Eliminar(id);
                if (!resultado)
                {
                    return BadRequest();
                }
                return NoContent();
            }
            catch (Exception excepcion)
            {
                return BadRequest();
            }
        }

        // POST: api/usuarios/cambiarcontrasena
        [HttpPost]
        [Route("cambiarcontrasena")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostCambiarContrasena(LoginModelDto usuarioContrasenaDto)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(usuarioContrasenaDto);
                var resultado = await _usuariosRepositorio.CambiarContrasena(usuario);
                if (!resultado)
                {
                    return BadRequest();
                }
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST: api/usuarios/cambiarperfil
        [HttpPost]
        [Route("cambiarperfil")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostCambiarPerfil(PerfilUsuarioDto perfilUsuarioDto)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(perfilUsuarioDto);

                var resultado = await _usuariosRepositorio.CambiarPerfil(usuario);
                if (!resultado)
                {
                    return BadRequest();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST: api/usuarios/validarusuario
        [HttpPost]
        [Route("validarusuario")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UsuarioRegistroDto>> PostValidarUsuario(LoginModelDto usuarioContrasenaDto)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(usuarioContrasenaDto);

                var resultado = await _usuariosRepositorio.ValidarContrasena(usuario);
                if (!resultado)
                {
                    return BadRequest();
                }
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
