using ApiTienda.Data;
using ApiTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Repositories
{
    public class RepositoryUsuarios
    {
        TiendaContext context;

        public RepositoryUsuarios(TiendaContext context)
        {
            this.context = context;
        }

        public List<Usuario> GetUsuarios()
        {
            return this.context.Usuarios.ToList();
        }

        public Usuario BuscarUsuario(int id)
        {
            return this.context.Usuarios.SingleOrDefault(x => x.IdUsuario == id);
        }


        public Usuario ExisteUsuario(String email)
        {
            return this.context.Usuarios
                 .SingleOrDefault(x => x.Email == email);
        }

        public void RegistrarUsuario(String nombre, string email, string password)
        {

            Usuario usuario = new Usuario();
            if (this.context.Usuarios.Count() == 0)
            {
                usuario.IdUsuario = 1;
            }
            else
            {
                usuario.IdUsuario = this.context.Usuarios.Max(a => a.IdUsuario + 1);
            }
            usuario.Nombre = nombre;
            usuario.Email = email;
            usuario.Password = BCrypt.Net.BCrypt.HashPassword(password);
            usuario.Rol = "USER";

            this.context.Usuarios.Add(usuario);
            this.context.SaveChanges();
        }

    }
}
