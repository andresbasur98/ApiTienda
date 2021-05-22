using ApiTienda.Data;
using ApiTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Repositories
{
    public class RepositoryPedidos
    {

        TiendaContext context;

        public RepositoryPedidos(TiendaContext context)
        {
            this.context = context;
        }

        public void InsertarPedido(int idusuario, String nombreclient, String apellclient, String direccion, String ciudad)
        {
            Pedido pedido = new Pedido();

            if (this.context.Pedidos.Count() == 0)
            {
                pedido.IdPedido = 1;

            }
            else
            {
                pedido.IdPedido = this.context.Pedidos.Max(a => a.IdPedido + 1);
            }
            pedido.IdUsuario = idusuario;
            pedido.NombreCliente = nombreclient;
            pedido.ApellidoCliente = apellclient;
            pedido.Direccion = direccion;
            pedido.Ciudad = ciudad;
            pedido.Fecha = DateTime.Today;

            this.context.Pedidos.Add(pedido);
            this.context.SaveChanges();
        }

        public Pedido GetPedido(int idpedido)
        {
            var consulta = from datos in this.context.Pedidos
                           where datos.IdPedido == idpedido
                           select datos;
            return consulta.FirstOrDefault();
        }
        public List<Pedido> GetPedidos()
        {
            var consulta = from datos in this.context.Pedidos
                           select datos;
            return consulta.ToList();
        }

        public List<Pedido> GetPedidosUsuario(int iduser)
        {
            var consulta = from datos in this.context.Pedidos
                           where datos.IdUsuario == iduser
                           select datos;
            return consulta.ToList();
        }


        //--------------------Consultas detalles pedidos ---------------------------------
        public void InsertDetallesPedido(int productoid, int cantidad)
        {
            DetallesPedido detail = new DetallesPedido();
            if (this.context.DetallesPedidos.Count() == 0)
            {
                detail.IdDetallesPedido = 1;
            }
            else
            {
                detail.IdDetallesPedido = this.context.DetallesPedidos.Max(a => a.IdDetallesPedido + 1);
            }
            detail.IdPedido = this.context.Pedidos.Max(a => a.IdPedido);
            detail.IdProducto = productoid;
            detail.Cantidad = cantidad;

            this.context.DetallesPedidos.Add(detail);
            this.context.SaveChanges();
        }

        //------------ Consultas Vista Detalles Pedidos ----------------- //

        public List<VistaDetallePedido> VerDetallesPedido(int id_pedido)
        {
            var consulta = from datos in this.context.VistaDetallePedidos
                           where datos.IdPedido == id_pedido
                           select datos;
            return consulta.ToList();
        }

    }
}
