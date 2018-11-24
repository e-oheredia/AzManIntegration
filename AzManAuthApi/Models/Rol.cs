using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AzManAuthApi.Models
{
    [Table("rol")]
    public class Rol
    {
        public Rol()
        {
            this.Usuarios = new HashSet<Usuario>();
            this.Operaciones = new HashSet<Operacion>();
        }
        [Column("id")]
        public int Id { get; set; }
        [Column("nombre")]
        [Required]
        [StringLength(50)]
        public string nombre { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<Operacion> Operaciones { get; set; }
    }
}