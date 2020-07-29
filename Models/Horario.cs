namespace SIGEM_TAEX.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Horario")]
    public partial class Horario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Horario()
        {
            Taller = new HashSet<Taller>();
        }

        [Key]
        public int ID_Horario { get; set; }

        [Required]
        [StringLength(50)]
        public string Dia { get; set; }

        [Required]
        [StringLength(50)]
        public string Hora { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Taller> Taller { get; set; }
    }
}
