using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace candidatas_library.Model
{
    [Table(name: "PermisosNegadosRol")]
    public class PermisoNegadoRol
    {
        [Key]
        public int pkPermisosNegadosRol { get; set; }

        public virtual Permiso fkPermiso { get; set; }

        public virtual Rol fkRol { get; set; }

        public Boolean bStatus { get; set; }

        public PermisoNegadoRol()
        {
            this.bStatus = true;

        }
    }
}
