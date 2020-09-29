using JMusik.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JMusik.WebApi.Services
{
    public class TokenService
    {
        private IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerarToken(Usuario usuario)
        {
            //Accedemos a la sección JwtSettings del archivo appsettings.json
            var jwtSettings = _configuration.GetSection("JwtSettings");
            //Obtenemos la clave secreta guardada en JwtSettings:SecretKey
            string secretKey = jwtSettings.GetValue<string>("SecretKey");
            //Obtenemos el tiempo de vida en minutos del Jwt guardada en JwtSettings:MinutesToExpiration
            int minutes = jwtSettings.GetValue<int>("MinutesToExpiration");
            //Obtenemos el valor del emisor del token en JwtSettings:Issuer
            string issuer = jwtSettings.GetValue<string>("Issuer");
            //Obtenemos el valor de la audiencia a la que está destinado el Jwt en JwtSettings:Audience
            string audience = jwtSettings.GetValue<string>("Audience");

            var key = Encoding.ASCII.GetBytes(secretKey);

            //Creamos nuestra lista de Claims, en este caso para el Username,
            //el Email y el Perfil del Usuario.
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name,usuario.Username));
            claims.Add(new Claim(ClaimTypes.Email, usuario.Email));
            claims.Add(new Claim(ClaimTypes.Role, usuario.Perfil.Nombre));
            

            // Creamos el objeto JwtSecurityToken
            var token = new JwtSecurityToken(
              issuer: issuer,             
              audience: audience,
              claims: claims,
              notBefore: DateTime.UtcNow,
              expires: DateTime.UtcNow.AddMinutes(minutes),
              signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            );

            // Creamos una representación en cadena del Token JWT (Json Web Token)
            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }
}
