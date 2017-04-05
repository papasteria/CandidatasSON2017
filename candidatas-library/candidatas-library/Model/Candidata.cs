using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace candidatas_library.Model
{
    [Table(name: "Candidatas")]
    public class Candidata
    {
        [Key]
        public int pkCandidata { get; set; }

        [Required(ErrorMessage = "este campo es requerido")]
        public DateTime dtAnioConvocatoria { get; set; }

        [Required(ErrorMessage = "este campo es requerido")]
        [StringLength(60)]
        public String sNombreCompleto { get; set; }

        [Required(ErrorMessage = "este campo es requerido")]
        public DateTime dtFechaNacimiento { get; set; }

        [Required(ErrorMessage = "este campo es requerido")]
        [StringLength(150)]
        public String sDescripcion { get; set; }


        [Required(ErrorMessage = "este campo es requerido")]
        [StringLength(40)]
        public String sCorreoElectronico { get; set; }


        [Required(ErrorMessage = "este campo es requerido")]
        [StringLength(20)]
        public String sCurp { get; set; }


        [Required(ErrorMessage = "este campo es requerido")]
        [StringLength(20)]
        public String sNivelEstudios { get; set; }

        public String sFotografiaRostro { get; set; }

        public Boolean bStatus { get; set; }

        public int iLike { get; set; }

        public virtual Municipio fkMunicipio { get; set; }

        public virtual Usuario fkUsuario { get; set; }

        public Candidata()
        {
            this.sFotografiaRostro = "as";
            this.iLike = 0;
            this.bStatus = true;
            this.dtAnioConvocatoria = DateTime.Now;
            this.dtFechaNacimiento = DateTime.Now;
        }
    }
}
