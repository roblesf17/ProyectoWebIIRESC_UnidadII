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

    [Table("Periodo")]
    public partial class Periodo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Periodo()
        {
            Matricula = new HashSet<Matricula>();
            Nota = new HashSet<Nota>();
        }

        [Key]
        public int ID_Periodo { get; set; }

        [Required]
        [StringLength(250)]
        public string Nombre_Periodo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Matricula> Matricula { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nota> Nota { get; set; }


        //Metodo Listar
        public List<Periodo> Listar() //retorna una lista o colección del objetos
        {
            var obj_periodo = new List<Periodo>();

            try
            {
                using (var db = new BDModeloTaex())
                {
                    obj_periodo = db.Periodo.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj_periodo; //Muestra o retorna todos los objetos almacenados
        }

        //Metodo Buscar
        public List<Periodo> Buscar(string Criterio) //retorna una lista o colección del objetos
        {
            var obj_periodo = new List<Periodo>();

            try
            {
                using (var db = new BDModeloTaex()) //ADO que creamos
                {
                    obj_periodo = db.Periodo
                                    .Where(x =>
                                                x.Nombre_Periodo.Contains(Criterio)  //se puede buscar por docente porque hemos incluido la tabla
                                                
                                                )
                                    .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj_periodo;
        }

        //Metodo Obtener
        public Periodo Obtener(int id) //retornar un objeto
        {
            var obj_periodo = new Periodo();

            try
            {
                using (var db = new BDModeloTaex())
                {
                    obj_periodo = db.Periodo
                                    .Where(x => x.ID_Periodo == id)
                                    .SingleOrDefault(); //devuelve un registro
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj_periodo;
        }

        //Método Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new BDModeloTaex())
                {
                    if (this.ID_Periodo > 0)
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
