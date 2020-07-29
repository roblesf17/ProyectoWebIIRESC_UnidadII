namespace SIGEM_TAEX.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public int ID_Usuario { get; set; }

        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Clave { get; set; }

        [Required]
        [StringLength(20)]
        public string Nivel { get; set; }

        [StringLength(250)]
        public string Avatar { get; set; }

        [StringLength(1)]
        public string Estado { get; set; }

        public int ID_Personal { get; set; }

        public int ID_Docente { get; set; }

        public int ID_Estudiante { get; set; }

        public virtual Docente Docente { get; set; }

        public virtual Estudiante Estudiante { get; set; }

        public virtual Personal_OBUN Personal_OBUN { get; set; }
    }
}
