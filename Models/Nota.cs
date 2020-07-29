namespace SIGEM_TAEX.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nota")]
    public partial class Nota
    {
        [Key]
        public int ID_Nota { get; set; }

        public decimal Evaluacion1 { get; set; }

        public decimal Evaluacion2 { get; set; }

        public decimal Evaluacion3 { get; set; }

        public decimal Promedio { get; set; }

        public int ID_Estudiante { get; set; }

        public int ID_Taller { get; set; }

        public int ID_Periodo { get; set; }

        public virtual Estudiante Estudiante { get; set; }

        public virtual Periodo Periodo { get; set; }

        public virtual Taller Taller { get; set; }
    }
}
