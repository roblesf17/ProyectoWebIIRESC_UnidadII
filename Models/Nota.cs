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

    [Table("Nota")]
    public partial class Nota
    {
        [Key]
        public int ID_Nota { get; set; }

        public decimal Evaluacion1 { get; set; }

        public decimal Evaluacion2 { get; set; }

        public decimal Evaluacion3 { get; set; }

        public decimal Promedio { get; set; }

        public int ID_Estudiante { get; set; }

        public int ID_Taller { get; set; }

        public int ID_Periodo { get; set; }

        public virtual Estudiante Estudiante { get; set; }

        public virtual Periodo Periodo { get; set; }

        public virtual Taller Taller { get; set; }

        //Mètodo Listar
        public List<Nota> Listar() //retorna una lista o colección del objetos
        {
            var obj_taller = new List<Nota>();

            try
            {
                using (var db = new BDModeloTaex())
                {
                    obj_taller = db.Nota.Include("Estudiante").Include("Taller").Include("Periodo").ToList(); //Debe listar lo que hay en mi Tabla Usuario
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj_taller; //Muestra o retorna todos los objetos almacenados
        }

        //Metodo Buscar
        public List<Nota> Buscar(string Criterio) //retorna una lista o colección del objetos
        {
            var obj_taller = new List<Nota>();
            try
            {
                using (var db = new BDModeloTaex()) //ADO que creamos
                {
                    obj_taller = db.Nota.Include("Estudiante").Include("Taller").Include("Periodo")
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
        public Nota Obtener(int id) //retornar un objeto
        {
            var obj_taller = new Nota();

            try
            {
                using (var db = new BDModeloTaex())
                {
                    obj_taller = db.Nota.Include("Estudiante").Include("Taller").Include("Periodo")
                                    .Where(x => x.ID_Nota == id)
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
                    if (this.ID_Nota > 0)
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
