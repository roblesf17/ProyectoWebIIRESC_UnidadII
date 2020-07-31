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

    [Table("Estudiante")]
    public partial class Estudiante
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Estudiante()
        {
            Asistencia = new HashSet<Asistencia>();
            Matricula = new HashSet<Matricula>();
            Nota = new HashSet<Nota>();
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        public int ID_Estudiante { get; set; }

        //public int ID_Usuario { get; set; }

        [StringLength(6)]
        public string Tipo_Identificacion { get; set; }

        public int? Numero_Identificacion { get; set; }

        [Required]
        [StringLength(250)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido_Paterno { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido_Materno { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha_Nacimiento { get; set; }

        public int Celular { get; set; }

        [Required]
        [StringLength(250)]
        public string Dirección { get; set; }

        [Required]
        [StringLength(150)]
        public string Correo { get; set; }

        [StringLength(1)]
        public string Sexo { get; set; }

        [StringLength(1)]
        public string Estado { get; set; }

        public int ID_Escuela { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asistencia> Asistencia { get; set; }

        public virtual Escuela_Profesional Escuela_Profesional { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Matricula> Matricula { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nota> Nota { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }

        //Metodo Listar

        public List<Estudiante> Listar() //retorna una lista o colección del objetos
        {
            var obj_usuarios = new List<Estudiante>();

            try
            {
                using (var db = new BDModeloTaex())
                {
                    obj_usuarios = db.Estudiante.Include("Escuela_Profesional").ToList(); //Debe listar lo que hay en mi Tabla Usuario
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj_usuarios; //Muestra o retorna todos los objetos almacenados
        }


        public List<Estudiante> Buscar(String Criterio) //retorna una lista o colección del objetos
        {
            var obj_usuarios = new List<Estudiante>();
            
            try
            {
                using (var db = new BDModeloTaex()) //ADO que creamos
                {
                    obj_usuarios = db.Estudiante.Include("Escuela_Profesional")
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
        public Estudiante Obtener(int id) //retornar un objeto
        {
            var obj_usuarios = new Estudiante();

            try
            {
                using (var db = new BDModeloTaex())
                {
                    obj_usuarios = db.Estudiante.Include("Escuela_Profesional")
                                    .Where(x => x.ID_Estudiante == id)
                                    .SingleOrDefault(); //devuelve un registro
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj_usuarios; //Muestra o retorna todos los objetos almacenados
        }

        //metodo guardar
        public void Guardar()
        {
            try
            {
                using (var db = new BDModeloTaex())
                {
                    if (this.ID_Estudiante > 0)
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
                throw ex;
            }
        }
    }
}
