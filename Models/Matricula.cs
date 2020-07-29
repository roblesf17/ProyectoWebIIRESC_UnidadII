namespace SIGEM_TAEX.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Matricula")]
    public partial class Matricula
    {
        [Key]
        public int ID_Matricula { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha_Inscripcion { get; set; }

        public decimal Costo_Taller { get; set; }

        public int ID_Estudiante { get; set; }

        public int ID_Taller { get; set; }

        public int ID_Periodo { get; set; }

        public virtual Estudiante Estudiante { get; set; }

        public virtual Periodo Periodo { get; set; }

        public virtual Taller Taller { get; set; }
    }
}
