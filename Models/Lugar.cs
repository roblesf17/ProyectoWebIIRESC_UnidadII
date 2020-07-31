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

    [Table("Lugar")]
    public partial class Lugar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lugar()
        {
            Taller = new HashSet<Taller>();
        }

        [Key]
        public int ID_Lugar { get; set; }

        [Required]
        [StringLength(250)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(250)]
        public string Referencia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Taller> Taller { get; set; }


        //Metodo Listar
        public List<Lugar> Listar() //retorna una lista o colección del objetos
        {
            var obj_lugar = new List<Lugar>();

            try
            {
                using (var db = new BDModeloTaex())
                {
                    obj_lugar = db.Lugar.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj_lugar; //Muestra o retorna todos los objetos almacenados
        }

        //Metodo Buscar
        public List<Lugar> Buscar(string Criterio) //retorna una lista o colección del objetos
        {
            var obj_lugar = new List<Lugar>();

            try
            {
                using (var db = new BDModeloTaex()) //ADO que creamos
                {
                    obj_lugar = db.Lugar

                                    .Where(x =>
                                                x.Direccion.Contains(Criterio) || //se puede buscar por docente porque hemos incluido la tabla
                                                x.Referencia.Contains(Criterio)
                                                )
                                    .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj_lugar;
        }

        //Metodo Obtener
        public Lugar Obtener(int id) //retornar un objeto
        {
            var obj_lugar = new Lugar();

            try
            {
                using (var db = new BDModeloTaex())
                {
                    obj_lugar = db.Lugar
                                    .Where(x => x.ID_Lugar == id)
                                    .SingleOrDefault(); //devuelve un registro
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj_lugar;
        }

        //Método Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new BDModeloTaex())
                {
                    if (this.ID_Lugar > 0)
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
