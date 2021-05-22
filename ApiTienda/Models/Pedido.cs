using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Models
{
    [Table("PEDIDO")]
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_PEDIDO")]
        public int IdPedido { get; set; }
        [Column("ID_USUARIO")]
        public int IdUsuario { get; set; }
        [Column("NOMBRE_CLIENTE")]
        public String NombreCliente { get; set; }
        [Column("APELLIDOS_CLIENTE")]
        public String ApellidoCliente { get; set; }
        [Column("CIUDAD")]
        public String Ciudad { get; set; }
        [Column("DIRECCION")]
        public String Direccion { get; set; }
        [Column("FECHA")]
        public DateTime Fecha { get; set; }
    }
}
