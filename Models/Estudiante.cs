namespace SIGEM_TAEX.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Estudiante")]
    public partial class Estudiante
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Estudiante()
        {
            Asistencia = new HashSet<Asistencia>();
            Matricula = new HashSet<Matricula>();
            Nota = new HashSet<Nota>();
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        public int ID_Estudiante { get; set; }

        public int ID_Usuario { get; set; }

        [StringLength(6)]
        public string Tipo_Identificacion { get; set; }

        public int? Numero_Identificacion { get; set; }

        [Required]
        [StringLength(250)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido_Paterno { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido_Materno { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha_Nacimiento { get; set; }

        public int Celular { get; set; }

        [Required]
        [StringLength(250)]
        public string Dirección { get; set; }

        [Required]
        [StringLength(150)]
        public string Correo { get; set; }

        [StringLength(1)]
        public string Sexo { get; set; }

        [StringLength(1)]
        public string Estado { get; set; }

        public int ID_Escuela { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asistencia> Asistencia { get; set; }

        public virtual Escuela_Profesional Escuela_Profesional { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Matricula> Matricula { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nota> Nota { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
