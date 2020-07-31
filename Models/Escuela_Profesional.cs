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

    public partial class Escuela_Profesional
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Escuela_Profesional()
        {
            Estudiante = new HashSet<Estudiante>();
        }

        [Key]
        public int ID_Escuela { get; set; }

        [Required]
        [StringLength(250)]
        public string Nombre_Escuela { get; set; }

        [Required]
        [StringLength(250)]
        public string Facultad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Estudiante> Estudiante { get; set; }


        //Listar
        public List<Escuela_Profesional> Listar() //retorna una lista o colección del objetos
        {
            var obj_escuela = new List<Escuela_Profesional>();

            try
            {
                using (var db = new BDModeloTaex())
                {
                    obj_escuela = db.Escuela_Profesional.ToList(); 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj_escuela; //Muestra o retorna todos los objetos almacenados
        }

        //Metodo Buscar
        public List<Escuela_Profesional> Buscar(string Criterio) //retorna una lista o colección del objetos
        {
            var obj_escuela = new List<Escuela_Profesional>();
            
            try
            {
                using (var db = new BDModeloTaex()) //ADO que creamos
                {
                    obj_escuela = db.Escuela_Profesional
                                    .Where(x =>
                                                x.Nombre_Escuela.Contains(Criterio) || //se puede buscar por docente porque hemos incluido la tabla
                                                x.Facultad.Contains(Criterio)
                                                )
                                    .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj_escuela;
        }

        //Metodo Obtener
        public Escuela_Profesional Obtener(int id) //retornar un objeto
        {
            var obj_escuela = new Escuela_Profesional();

            try
            {
                using (var db = new BDModeloTaex())
                {
                    obj_escuela = db.Escuela_Profesional
                                    .Where(x => x.ID_Escuela == id)
                                    .SingleOrDefault(); //devuelve un registro
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj_escuela; 
        }

        //guardar
        public void Guardar()
        {
            try
            {
                using (var db = new BDModeloTaex())
                {
                    if (this.ID_Escuela > 0)
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
