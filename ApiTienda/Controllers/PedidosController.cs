using ApiTienda.Models;
using ApiTienda.Repositories;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class PedidosController : ControllerBase
    {
        RepositoryPedidos repo;
        public PedidosController(RepositoryPedidos repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Pedido>> GetPedidos()
        {
            return this.repo.GetPedidos().ToList();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult<Pedido> GetPedido(int id)
        {
            return this.repo.GetPedido(id);
        }

        [HttpGet]
        [Route("[action]/{id}")]

        public ActionResult<List<Pedido>> GetPedidosUsuario(int id)
        {
            return this.repo.GetPedidosUsuario(id).ToList();
        }

        [HttpPost]
        public void InsertarPedido(Pedido pedido)
        {
            this.repo.InsertarPedido(pedido.IdUsuario, pedido.NombreCliente, pedido.ApellidoCliente, pedido.Direccion, pedido.Ciudad);
        }

        [HttpGet]
        [Route("detallepedido/{id}")]
        public ActionResult<List<VistaDetallePedido>> DetallePedido(int id)
        {
            return this.repo.VerDetallesPedido(id);
        }

        [HttpPost]
        [Route("detallepedido")]
        public void InsertarDetallePedido(DetallesPedido detailpedido)
        {
            this.repo.InsertDetallesPedido(detailpedido.IdProducto, detailpedido.Cantidad);
        }

       

    }
}
