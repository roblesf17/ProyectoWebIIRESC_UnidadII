namespace SIGEM_TAEX.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Personal_OBUN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personal_OBUN()
        {
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        public int ID_Personal { get; set; }

        public int DNI { get; set; }

        [Required]
        [StringLength(250)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido_Paterno { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido_Materno { get; set; }

        public int Celular { get; set; }

        [Required]
        [StringLength(150)]
        public string Correo { get; set; }

        [Required]
        [StringLength(250)]
        public string Direccion { get; set; }

        [StringLength(1)]
        public string Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
