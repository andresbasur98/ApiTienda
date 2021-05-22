using ApiTienda.Models;
using ApiTienda.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        RepositoryProductos repo;

        public ProductosController(RepositoryProductos repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Producto>> GetProductos()
        {
            return this.repo.GetProductos();
        }

        [HttpGet("{id}")]
        public ActionResult<Producto> BuscarProducto(int id)
        {
            return this.repo.BuscarProducto(id);
        }

        [HttpGet("[action]/{id}")]
        public ActionResult<List<Producto>> ProductosPorCategoria(int id)
        {
            return this.repo.GetProductosCategory(id);
        }

        [HttpPost]
        public void InsertarProducto(Producto producto)
        {
            this.repo.InsertProducto(producto.IdCategoria, producto.Nombre, producto.Precio, producto.Imagen, producto.Stock, producto.Descripcion);
        }

        [HttpPut]
        public void UpdateProducto(Producto producto)
        {
            this.repo.EditarProducto(producto.IdProducto, producto.IdCategoria, producto.Nombre, producto.Precio, producto.Imagen, producto.Stock, producto.Descripcion);
        }

        [HttpGet("[action]")]
        public List<Producto> GetProductosCarrito([FromQuery(Name = "ids")] int[] ids)
        {
            return this.repo.GetProductosCarrito(ids);
        }
        
    }
}
