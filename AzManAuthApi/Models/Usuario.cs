using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AzManAuthApi.Models
{
    [Table("usuario")]
    public class Usuario
    {
        public Usuario()
        {
            this.Roles = new HashSet<Rol>();
            this.Aplicaciones = new HashSet<Aplicacion>();
        }
        [Column("usuario_id")]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [Column("nombre")]
        public string Nombre { get; set; }
        public virtual ICollection<Aplicacion> Aplicaciones { get; set; }
        public virtual ICollection<Rol> Roles { get; set; }
    }
}