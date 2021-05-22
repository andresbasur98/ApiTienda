using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Models
{
    [Table("DETALLES_PEDIDO")]
    public class DetallesPedido
    {
        [Key]
        [Column("ID_DETALLESP")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdDetallesPedido { get; set; }
        [Column("ID_PEDIDO")]
        public int IdPedido { get; set; }
        [Column("ID_PRODUCTO")]
        public int IdProducto { get; set; }
        [Column("CANTIDAD")]
        public int Cantidad { get; set; }
    }
}
