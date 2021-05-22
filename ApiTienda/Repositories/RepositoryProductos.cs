using ApiTienda.Data;
using ApiTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Repositories
{
    public class RepositoryProductos
    {
        TiendaContext context;

        public RepositoryProductos(TiendaContext context)
        {
            this.context = context;
        }

        public List<Producto> GetProductos()
        {
            return this.context.Productos.ToList();
        }

        public List<Producto> GetUltimosTres()
        {
            var consulta = (from datos in this.context.Productos
                           select datos).OrderByDescending(x => x.IdProducto).Take(3);
            return consulta.ToList();

        }

        public Producto BuscarProducto(int idproducto)
        {
            return this.context.Productos
                .SingleOrDefault(x => x.IdProducto == idproducto);
        }

        
        public List<Producto> GetProductosCategory(int idcategory)
        {
            var consulta = from datos in this.context.Productos
                           where datos.IdCategoria == idcategory
                           select datos;
            return consulta.ToList();
        }
        public List<Producto> GetProductosCarrito(int[] idsproducts)
        {
            var consulta = from datos in this.context.Productos
                           where idsproducts.Contains(datos.IdProducto)
                           select datos;
            return consulta.ToList();
        }


        public void InsertProducto( int idcategoria, String nombre, Decimal precio, String imagen, 
            int stock, String descripcion)
        {
            Producto producto = new Producto();

            if (this.context.Productos.Count() == 0)
            {
                producto.IdProducto = 1;
            }
            else
            {
                producto.IdProducto = this.context.Productos.Max(a => a.IdProducto + 1);
            }
            producto.IdCategoria = idcategoria;
            producto.Nombre = nombre;
            producto.Precio = precio;
            producto.Imagen = imagen;
            producto.Stock = stock;
            producto.Descripcion = descripcion;

            this.context.Productos.Add(producto);
            this.context.SaveChanges();
        }

        public void EditarProducto(int idproducto, int categoria, String nombre, Decimal precio, String imagen, int stock, String descripcion)
        {
            Producto product = this.BuscarProducto(idproducto);
            product.IdCategoria = categoria;
            product.Nombre = nombre;
            product.Precio = precio;
            product.Imagen = imagen;
            product.Stock = stock;
            product.Descripcion = descripcion;

            this.context.SaveChanges();

        }
    }
}
