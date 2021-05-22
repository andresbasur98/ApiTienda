using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Models
{
    [Table("USUARIO")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_USUARIO")]
        public int IdUsuario { get; set; }
        [Column("NOMBRE")]
        public String Nombre { get; set; }
        [Column("EMAIL")]
        public String Email { get; set; }
        [Column("CONTRASEÑA")]
        public String Password { get; set; }
        [Column("ROL")]
        public String Rol { get; set; }
    }
}
