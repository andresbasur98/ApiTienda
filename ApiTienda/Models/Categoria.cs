using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Models
{
    [Table("CATEGORIA")]
    public class Categoria
    {
        [Key]
        [Column("ID_CATEGORIA")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdCategoria { get; set; }
        [Column("NOMBRE")]
        public String Nombre { get; set; }
        [Column("DESCRIPCION")]
        public String Descripcion { get; set; }
    }
}
