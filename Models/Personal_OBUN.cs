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

    public partial class Personal_OBUN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personal_OBUN()
        {
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        public int ID_Personal { get; set; }

        public int DNI { get; set; }

        [Required]
        [StringLength(250)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido_Paterno { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido_Materno { get; set; }

        public int Celular { get; set; }

        [Required]
        [StringLength(150)]
        public string Correo { get; set; }

        [Required]
        [StringLength(250)]
        public string Direccion { get; set; }

        [StringLength(1)]
        public string Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }


        //listar
        public List<Personal_OBUN> Listar() //retorna una lista o colección del objetos
        {
            var obj_usuarios = new List<Personal_OBUN>();

            try
            {
                using (var db = new BDModeloTaex())
                {
                    obj_usuarios = db.Personal_OBUN.ToList(); //Debe listar lo que hay en mi Tabla Usuario
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj_usuarios; //Muestra o retorna todos los objetos almacenados
        }

        //Metodo Buscar
        public List<Personal_OBUN> Buscar(string Criterio) //retorna una lista o colección del objetos
        {
            var obj_usuarios = new List<Personal_OBUN>();

            try
            {
                using (var db = new BDModeloTaex()) //ADO que creamos
                {
                    obj_usuarios = db.Personal_OBUN
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
        public Personal_OBUN Obtener(int id) //retornar un objeto
        {
            var obj_usuarios = new Personal_OBUN();

            try
            {
                using (var db = new BDModeloTaex())
                {
                    obj_usuarios = db.Personal_OBUN
                                    .Where(x => x.ID_Personal == id)
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
                    if (this.ID_Personal > 0)
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
