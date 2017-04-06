using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace candidatas_library.Model
{
    public class DataModel:DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<PermisoNegadoRol> PermisosNegadosRol { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<Candidata> Candidatas { get; set; }
        public DbSet<Municipio> Municipios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DataModel() : base("DataModel") { }
    }
}
