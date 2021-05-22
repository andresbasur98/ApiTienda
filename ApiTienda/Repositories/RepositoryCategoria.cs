using ApiTienda.Data;
using ApiTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Repositories
{
    public class RepositoryCategoria
    {
        TiendaContext context;

        public RepositoryCategoria(TiendaContext context)
        {
            this.context = context;
        }

        public List<Categoria> GetCategorias()
        {
            var consulta = from datos in this.context.Categorias
                           select datos;
            return consulta.ToList();
        }

        public Categoria GetCategoria(int idcategoria)
        {
            var consulta = from datos in this.context.Categorias
                           where datos.IdCategoria == idcategoria
                           select datos;
            return consulta.FirstOrDefault();
        }

        public void InsertarCategoria(String nombre, String descripcion)
        {
            Categoria category = new Categoria();

            if (this.context.Categorias.Count() == 0)
            {
                category.IdCategoria = 1;
            }
            else
            {
                category.IdCategoria = this.context.Categorias.Max(a => a.IdCategoria + 1);
            }

            category.Nombre = nombre;
            category.Descripcion = descripcion;

            this.context.Categorias.Add(category);
            this.context.SaveChanges();
        }
        
        public void EditarCategoria(int idcategory, String nombre, String descripcion)
        {
            Categoria category = this.GetCategoria(idcategory);
            category.Nombre = nombre;
            category.Descripcion = descripcion;

            this.context.SaveChanges();
        }

    }
}
