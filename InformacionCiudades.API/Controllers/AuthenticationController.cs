using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InformacionCiudades.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;

        public class AuthenticationRequestBody
        {
            public string? UserName { get; set; }
            public string? Password { get; set; }
        }

        public AuthenticationController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate(AuthenticationRequestBody authenticationRequestBody)
        {
            //Paso 1: Validamos las credenciales
            var usuario = ValidarCredenciales(authenticationRequestBody.UserName, authenticationRequestBody.Password);

            if (usuario is null)
                return Unauthorized();

            //Paso 2: Crear el token
            var claveDeSeguridad = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"]));

            var credenciales = new SigningCredentials(claveDeSeguridad, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", usuario.Id.ToString()));
            claimsForToken.Add(new Claim("given_name", usuario.Nombre));
            claimsForToken.Add(new Claim("family_name", usuario.Apellido));
            claimsForToken.Add(new Claim("city", "Rosario")); //Debería venir del usuario

            var jwtSecurityToken = new JwtSecurityToken(
              _config["Authentication:Issuer"],
              _config["Authentication:Audience"],
              claimsForToken,
              DateTime.UtcNow,
              DateTime.UtcNow.AddHours(1),
              credenciales);

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }

        private Usuario ValidarCredenciales(string? userName, string? password)
        {
            return new Usuario(1, "nbologna", "123456", "Nicolas", "Bologna");
        }

        private class Usuario //Es una clase a modo de prueba para el ejemplo
        {
            public Usuario(int id, string userName, string password, string apellido, string nombre)
            {
                Id = id;
                UserName = userName;
                Password = password;
                Apellido = apellido;
                Nombre = nombre;
            }

            public int Id { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
        }
    }
}
