using ApiTienda.Models;
using ApiTienda.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApiTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        RepositoryUsuarios repo;

        public UsuarioController(RepositoryUsuarios repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Usuario>> GetUsuarios()
        {
            return this.repo.GetUsuarios();
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> BuscarUsuario(int id)
        {
            return this.repo.BuscarUsuario(id);
        }

        [HttpPost]
        public void CrearUsuario(Usuario user)
        {
            this.repo.RegistrarUsuario(user.Nombre, user.Email, user.Password);
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public ActionResult<Usuario> PerfilEmpleado()
        {
           
            List<Claim> claims =
                HttpContext.User.Claims.ToList();
            //BUSCAMOS EL JSON DEL EMPLEADO, GUARDADO CON LA KEY UserData
            String jsonusuario =
                claims.SingleOrDefault(x => x.Type == "UserData").Value;
            Usuario usuario =
                JsonConvert.DeserializeObject<Usuario>(jsonusuario);
            return usuario;
        }
    }
}
