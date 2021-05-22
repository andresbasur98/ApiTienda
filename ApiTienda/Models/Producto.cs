using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Models
{
    [Table("PRODUCTO")]
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_PRODUCTO")]
        public int IdProducto { get; set; }
        [Column("ID_CATEGORIA")]
        public int IdCategoria { get; set; }
        [Column("NOMBRE")]
        public String Nombre { get; set; }
        [Column("PRECIO")]
        public Decimal Precio { get; set; }
        [Column("IMAGEN")]
        public String Imagen { get; set; }
        [Column("STOCK")]
        public int Stock { get; set; }
        [Column("DESCRIPCION")]
        public String Descripcion { get; set; }

    }
}
