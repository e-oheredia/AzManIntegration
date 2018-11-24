using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AzManAuthApi.Models
{
    [Table("operacion")]
    public class Operacion
    {
        public Operacion()
        {
            this.Roles = new HashSet<Rol>();
        }
        [Column("operacion_id")]
        public int Id { get; set; }
        [Column("nombre")]
        [Required]
        [StringLength(50)]
        public string nombre { get; set; }
        public virtual ICollection<Rol> Roles { get; set; }
    }
}