namespace SIGEM_TAEX.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Taller")]
    public partial class Taller
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Taller()
        {
            Asistencia = new HashSet<Asistencia>();
            Matricula = new HashSet<Matricula>();
            Nota = new HashSet<Nota>();
        }

        [Key]
        public int ID_Taller { get; set; }

        [Required]
        [StringLength(250)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(250)]
        public string Categoria { get; set; }

        public int Cantidad_Inscritos { get; set; }

        public int Cupos_Disponibles { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha_Inicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha_Fin { get; set; }

        [StringLength(1)]
        public string Estado { get; set; }

        public int ID_Docente { get; set; }

        public int ID_Lugar { get; set; }

        public int ID_Horario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asistencia> Asistencia { get; set; }

        public virtual Docente Docente { get; set; }

        public virtual Horario Horario { get; set; }

        public virtual Lugar Lugar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Matricula> Matricula { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nota> Nota { get; set; }
    }
}
