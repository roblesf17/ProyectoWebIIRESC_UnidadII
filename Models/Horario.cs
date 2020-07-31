namespace SIGEM_TAEX.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Data.Entity;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;



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

        [Required]
        [StringLength(50)]
        public string Hora_Fin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Taller> Taller { get; set; }

        //Metodo Listar
        public List<Horario> Listar() //retorna una lista o colección del objetos
        {
            var obj_horario = new List<Horario>();

            try
            {
                using (var db = new BDModeloTaex())
                {
                    obj_horario = db.Horario.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj_horario; //Muestra o retorna todos los objetos almacenados
        }

        //Metodo Buscar
        public List<Horario> Buscar(string Criterio) //retorna una lista o colección del objetos
        {
            var obj_horario = new List<Horario>();

            try
            {
                using (var db = new BDModeloTaex()) //ADO que creamos
                {
                    obj_horario = db.Horario
                                    .Where(x =>
                                                x.Dia.Contains(Criterio) || //se puede buscar por docente porque hemos incluido la tabla
                                                x.Hora.Contains(Criterio)
                                                )
                                    .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj_horario;
        }

        //Metodo Obtener
        public Horario Obtener(int id) //retornar un objeto
        {
            var obj_horario = new Horario();

            try
            {
                using (var db = new BDModeloTaex())
                {
                    obj_horario = db.Horario
                                    .Where(x => x.ID_Horario == id)
                                    .SingleOrDefault(); //devuelve un registro
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj_horario;
        }

        //Método Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new BDModeloTaex())
                {
                    if (this.ID_Horario > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Método Eliminar
        public void Eliminar()
        {
            try
            {
                using (var db = new BDModeloTaex())
                {
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
