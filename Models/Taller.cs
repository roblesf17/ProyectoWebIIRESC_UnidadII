namespace SIGEM_TAEX.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    using System.Data.Entity.Validation;
    using System.IO;
    using System.Data.Entity;

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

        //Mètodo Listar
        public List<Taller> Listar() //retorna una lista o colección del objetos
        {
            var obj_taller = new List<Taller>();

            try
            {
                using (var db = new BDModeloTaex())
                {
                    obj_taller = db.Taller.Include("Docente").Include("Horario").Include("Lugar").ToList(); //Debe listar lo que hay en mi Tabla Usuario
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj_taller; //Muestra o retorna todos los objetos almacenados
        }

        //Metodo Buscar
        public List<Taller> Buscar(string Criterio) //retorna una lista o colección del objetos
        {
            var obj_taller = new List<Taller>();
            try
            {
                using (var db = new BDModeloTaex()) //ADO que creamos
                {
                    obj_taller = db.Taller
                                    .Where(x =>
                                                x.Nombre.Contains(Criterio) || //se puede buscar por docente porque hemos incluido la tabla
                                                x.Categoria.Contains(Criterio)
                                                )
                                    .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj_taller;
        }


        //Metodo Obtener
        public Taller Obtener(int id) //retornar un objeto
        {
            var obj_taller = new Taller();

            try
            {
                using (var db = new BDModeloTaex())
                {
                    obj_taller = db.Taller.Include("Docente").Include("Horario").Include("Lugar")
                                    .Where(x => x.ID_Taller == id)
                                    .SingleOrDefault(); //devuelve un registro
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj_taller;
        }

        //metodo guardar
        public void Guardar()
        {
            try
            {
                using (var db = new BDModeloTaex())
                {
                    if (this.ID_Taller > 0)
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
                throw;
            }
        }

        //eliminar
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
                throw;
            }
        }


    }
}
