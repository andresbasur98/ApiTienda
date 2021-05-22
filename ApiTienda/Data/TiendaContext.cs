using ApiTienda.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Data
{
    public class TiendaContext: DbContext
    {
        public TiendaContext(DbContextOptions<TiendaContext> options) : base(options) { } 
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallesPedido> DetallesPedidos { get; set; }
        public DbSet<VistaDetallePedido> VistaDetallePedidos { get; set; }

    }
}
