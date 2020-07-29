namespace SIGEM_TAEX.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Asistencia")]
    public partial class Asistencia
    {
        [Key]
        public int ID_Asistencia { get; set; }

        [Column("Asistencia")]
        [StringLength(2)]
        public string Asistencia1 { get; set; }

        [StringLength(2)]
        public string Tardanza { get; set; }

        [StringLength(2)]
        public string Inasistencia { get; set; }

        public int ID_Estudiante { get; set; }

        public int ID_Taller { get; set; }

        public virtual Estudiante Estudiante { get; set; }

        public virtual Taller Taller { get; set; }
    }
}
