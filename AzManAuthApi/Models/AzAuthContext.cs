using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AzManAuthApi.Models
{
    public class AzAuthContext: DbContext
    {
        public AzAuthContext()
            :base("DefaultConnection")
        {

        }

        public DbSet<Aplicacion> Aplicacion { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Operacion> Operacion { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aplicacion>()
                .HasMany(a => a.Usuarios)
                .WithMany(u => u.Aplicaciones)
                .Map(ua =>
                {
                    ua.MapLeftKey("aplicacion_id");
                    ua.MapRightKey("usuario_id");
                    ua.ToTable("usuario_aplicacion");
                });
            
            modelBuilder.Entity<Usuario>()
                .HasMany(a => a.Roles)
                .WithMany(u => u.Usuarios)
                .Map(ua =>
                {
                    ua.MapLeftKey("usuario_id");
                    ua.MapRightKey("rol_id");
                    ua.ToTable("rol_usuario");
                });
            modelBuilder.Entity<Rol>()
                .HasMany(a => a.Operaciones)
                .WithMany(u => u.Roles)
                .Map(ua =>
                {
                    ua.MapLeftKey("rol_id");
                    ua.MapRightKey("operacion_id");
                    ua.ToTable("operacion_rol");
                });
            

        }
    }
}