using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AzManAuthApi.Models
{
    [Table("aplicacion")]
    public class Aplicacion
    {
        public Aplicacion()
        {
            this.Usuarios = new HashSet<Usuario>();
        }

        [Column("aplicacion_id")]
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        [Column("nombre")]
        public string Nombre { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}