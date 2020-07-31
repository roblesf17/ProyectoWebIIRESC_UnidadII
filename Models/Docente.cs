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

    [Table("Docente")]
    public partial class Docente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Docente()
        {
            Taller = new HashSet<Taller>();
            Usuario = new HashSet<Usuario>();
        }

        

        [Key]
        public int ID_Docente { get; set; }

        public int DNI { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido_Paterno { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido_Materno { get; set; }

        [Required]
        [StringLength(250)]
        public string Correo { get; set; }

        public int Celular { get; set; }

        [Required]
        [StringLength(250)]
        public string Direccion { get; set; }

        [StringLength(1)]
        public string Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Taller> Taller { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }

        public List<Docente> Listar() //retorna una lista o colección del objetos
        {
            var obj_usuarios = new List<Docente>();

            try
            {
                using (var db = new BDModeloTaex())
                {
                    obj_usuarios = db.Docente.ToList(); //Debe listar lo que hay en mi Tabla Usuario
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj_usuarios; //Muestra o retorna todos los objetos almacenados
        }

        //Metodo Buscar
        public List<Docente> Buscar(string Criterio) //retorna una lista o colección del objetos
        {
            var obj_usuarios = new List<Docente>();
            try
            {
                using (var db = new BDModeloTaex()) //ADO que creamos
                {
                    obj_usuarios = db.Docente
                                    .Where(x =>
                                                x.Nombres.Contains(Criterio) || //se puede buscar por docente porque hemos incluido la tabla
                                                x.Apellido_Paterno.Contains(Criterio)
                                                )
                                    .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj_usuarios;
        }

        //Metodo Obtener
        public Docente Obtener(int id) //retornar un objeto
        {
            var obj_usuarios = new Docente();

            try
            {
                using (var db = new BDModeloTaex())
                {
                    obj_usuarios = db.Docente
                                    .Where(x => x.ID_Docente == id)
                                    .SingleOrDefault(); //devuelve un registro
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj_usuarios;
        }

        //guardar
        public void Guardar()
        {
            try
            {
                using (var db = new BDModeloTaex())
                {
                    if (this.ID_Docente > 0)
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
