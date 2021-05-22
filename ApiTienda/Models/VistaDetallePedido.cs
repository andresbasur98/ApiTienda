using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Models
{
    [Table("DETALLEPEDIDO")]
    public class VistaDetallePedido
    {
        [Key]
        [Column("ID_DETALLESP")]
        public int IdDetallesP { get; set; }
        [Column("ID_PEDIDO")]
        public int IdPedido { get; set; }
        [Column("ID_PRODUCTO")]
        public int IdProducto { get; set; }
        [Column("NOMBRE")]
        public String NombreProducto { get; set; }
        [Column("Precio")]
        public Decimal Precio { get; set; }
        [Column("Imagen")]
        public String Imagen { get; set; }
        [Column("Cantidad")]
        public int CantidadProducto { get; set; }
        [Column("Direccion")]
        public String Direccion { get; set; }
        [Column("Fecha")]
        public DateTime Fecha { get; set; }
    }
}
