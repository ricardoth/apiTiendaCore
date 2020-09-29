using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JMusik.Data.Contratos;
using JMusik.Dtos;
using JMusik.Models;
using JMusik.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JMusik.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesionController : ControllerBase
    {
        private IUsuariosRepositorio _usuariosRepositorio;
        private IMapper _mapper;
        private TokenService _tokenService;

        public SesionController(IUsuariosRepositorio usuariosRepositorio,
                                IMapper mapper,
                                TokenService tokenService)
        {
            _usuariosRepositorio = usuariosRepositorio;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        //POST: api/sesion/login
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> PostLogin(LoginModelDto usuarioLogin)
        {
            var datosLoginUsuario = _mapper.Map<Usuario>(usuarioLogin);

            var resultadoValidacion = await _usuariosRepositorio.ValidarDatosLogin(datosLoginUsuario);
            if (!resultadoValidacion.resultado)
            {
                return BadRequest("Usuario/Contraseña Inválidos.");
            }
            return _tokenService.GenerarToken(resultadoValidacion.usuario);

        }

    }
}
