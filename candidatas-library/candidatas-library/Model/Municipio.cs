using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace candidatas_library.Model
{
    [Table(name: "Municipios")]
    public class Municipio
    {
        [Key]
        public int pkMunicipio { get; set; }

        [Required(ErrorMessage = "Se require el nombre del municipio")]
        [StringLength(40)]
        public String sNombre { get; set; }

        public String sLogotipo { get; set; }

        [Required(ErrorMessage = "Se require la descripcion del municipio")]
        [StringLength(150)]
        public String sDescripcion { get; set; }

        public Boolean bStatus { get; set; }

        public Municipio()
        {
            this.sLogotipo = "as";
            this.bStatus = true;
        }

        public ICollection<Candidata> Candidatas { get; set; }
    }
}
