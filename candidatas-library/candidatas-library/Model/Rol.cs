using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace candidatas_library.Model
{
    [Table(name: "Roles")]
    public class Rol
    {
        [Key]
        public int pkRoles { get; set; }

        [Required(ErrorMessage = "Se require el nombre del municipio")]
        [StringLength(100)]
        public String sNombre { get; set; }

        [Required(ErrorMessage = "Se require la descripcion del municipio")]
        [StringLength(150)]
        public String sDescripcion { get; set; }

        [Required(ErrorMessage = "Se require el status")]
        public Boolean bStatus { get; set; }

        public Rol()
        {
            this.bStatus = true;

        }

        public ICollection<Usuario> Usuarios { get; set; }
        public ICollection<PermisoNegadoRol> PermisosNegadosRol { get; set; }
    }
}
