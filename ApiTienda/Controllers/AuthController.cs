using ApiTienda.Helpers;
using ApiTienda.Models;
using ApiTienda.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApiTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        RepositoryUsuarios repo;
        HelperToken helpertoken;

        public AuthController(RepositoryUsuarios repo, HelperToken helpertoken)
        {
            this.repo = repo;
            this.helpertoken = helpertoken;
        }

        [HttpPost]
        [Route("[action]")]
        public void Register(Usuario usuario)
        {
            string password = BCrypt.Net.BCrypt.HashPassword(usuario.Password);
            this.repo.RegistrarUsuario(usuario.Nombre, usuario.Email, usuario.Password);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login(LoginModel model)
        {
            Usuario usuario = this.repo.ExisteUsuario(model.Email);

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(model.Password, usuario.Password);

            if(usuario == null || !isValidPassword)
            {
                return Unauthorized();
            }
            else
            {
                String usuariojson = JsonConvert.SerializeObject(usuario);
                Claim[] claims = new[] {
                    new Claim("UserData", usuariojson)
                };

                JwtSecurityToken token = new JwtSecurityToken(
                   issuer: this.helpertoken.Issuer,
                   audience: this.helpertoken.Audience,
                   claims: claims,
                   expires: DateTime.UtcNow.AddMinutes(50),
                   notBefore: DateTime.UtcNow,
                   signingCredentials:
                   new SigningCredentials(this.helpertoken.GetKeyToken()
                   , SecurityAlgorithms.HmacSha256));
                //DEVOLVEMOS UNA RESPUESTA DE ACCESO
                //QUE INCLUIRA EL TOKEN GENERADO
                return Ok(
                    new
                    {
                        response = new JwtSecurityTokenHandler().WriteToken(token)
                    });

            }

        }
    }
}
