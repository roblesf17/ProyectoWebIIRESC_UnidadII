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

    [Table("Matricula")]
    public partial class Matricula
    {
        [Key]
        public int ID_Matricula { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha_Inscripcion { get; set; }

        public decimal Costo_Taller { get; set; }

        public int ID_Estudiante { get; set; }

        public int ID_Taller { get; set; }

        public int ID_Periodo { get; set; }

        public virtual Estudiante Estudiante { get; set; }

        public virtual Periodo Periodo { get; set; }

        public virtual Taller Taller { get; set; }


        //Mètodo Listar
        public List<Matricula> Listar() //retorna una lista o colección del objetos
        {
            var obj_taller = new List<Matricula>();

            try
            {
                using (var db = new BDModeloTaex())
                {
                    obj_taller = db.Matricula.Include("Estudiante").Include("Taller").Include("Periodo").ToList(); //Debe listar lo que hay en mi Tabla Usuario
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj_taller; //Muestra o retorna todos los objetos almacenados
        }

        //Metodo Buscar
        public List<Matricula> Buscar(string Criterio) //retorna una lista o colección del objetos
        {
            var obj_taller = new List<Matricula>();
            try
            {
                using (var db = new BDModeloTaex()) //ADO que creamos
                {
                    obj_taller = db.Matricula
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
        public Matricula Obtener(int id) //retornar un objeto
        {
            var obj_taller = new Matricula();

            try
            {
                using (var db = new BDModeloTaex())
                {
                    obj_taller = db.Matricula.Include("Estudiante").Include("Taller").Include("Periodo")
                                    .Where(x => x.ID_Matricula == id)
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
                    if (this.ID_Matricula > 0)
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
