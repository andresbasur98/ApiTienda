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
    public class CategoriaController : ControllerBase
    {
        RepositoryCategoria repo;
        public CategoriaController(RepositoryCategoria repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Categoria>> GetCategorias()
        {
            return this.repo.GetCategorias().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Categoria> GetCategoria(int id)
        {
            return this.repo.GetCategoria(id);
        }

        [HttpPost]
        public void InsertCategoria(Categoria categoria)
        {
            this.repo.InsertarCategoria(categoria.Nombre, categoria.Descripcion);
        }

        [HttpPut]
        public void EditarCategoria(Categoria categoria)
        {
            this.repo.EditarCategoria(categoria.IdCategoria, categoria.Nombre, categoria.Descripcion);
        }
    }
}
