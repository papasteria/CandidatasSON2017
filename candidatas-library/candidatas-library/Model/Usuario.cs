using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace candidatas_library.Model
{
    [Table(name: "Usuarios")]
    public class Usuario
    {
        [Key]
        public int pkUsuario { get; set; }

        [Required(ErrorMessage = "Se require el status")]
        public int iEmpleadoUsuario { get; set; }

        [Required(ErrorMessage = "este campo es requerido")]
        [StringLength(100)]
        public String sPassword { get; set; }

        [Required(ErrorMessage = "Se require el status")]
        public Boolean bStatus { get; set; }

        public virtual Rol fkRoles { get; set; }

        public Usuario()
        {
            this.iEmpleadoUsuario = 0;
            this.bStatus = true;
        }

        public ICollection<Candidata> Candidatas { get; set; }
    }
}
