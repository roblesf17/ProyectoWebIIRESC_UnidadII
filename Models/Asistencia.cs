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

        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }

        public virtual Estudiante Estudiante { get; set; }

        public virtual Taller Taller { get; set; }

        //Mètodo Listar
        public List<Asistencia> Listar() //retorna una lista o colección del objetos
        {
            var obj_taller = new List<Asistencia>();

            try
            {
                using (var db = new BDModeloTaex())
                {
                    obj_taller = db.Asistencia.Include("Estudiante").Include("Taller").ToList(); //Debe listar lo que hay en mi Tabla Usuario
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj_taller; //Muestra o retorna todos los objetos almacenados
        }

        //Metodo Buscar
        public List<Asistencia> Buscar(string Criterio) //retorna una lista o colección del objetos
        {
            var obj_taller = new List<Asistencia>();
            try
            {
                using (var db = new BDModeloTaex()) //ADO que creamos
                {
                    obj_taller = db.Asistencia
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
        public Asistencia Obtener(int id) //retornar un objeto
        {
            var obj_taller = new Asistencia();

            try
            {
                using (var db = new BDModeloTaex())
                {
                    obj_taller = db.Asistencia.Include("Estudiante").Include("Taller")
                                    .Where(x => x.ID_Asistencia == id)
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
                    if (this.ID_Asistencia > 0)
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
