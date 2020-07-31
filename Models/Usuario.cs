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

    using SIGEM_TAEX.Filters;

    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public int ID_Usuario { get; set; }

        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Clave { get; set; }

        [Required]
        [StringLength(20)]
        public string Nivel { get; set; }

        [StringLength(250)]
        public string Avatar { get; set; }

        [StringLength(1)]
        public string Estado { get; set; }

        public int ID_Personal { get; set; }

        public int ID_Docente { get; set; }

        public int ID_Estudiante { get; set; }

        public virtual Docente Docente { get; set; }

        public virtual Estudiante Estudiante { get; set; }

        public virtual Personal_OBUN Personal_OBUN { get; set; }

        public List<Usuario> Listar() //retorna una lista o colección del objetos
        {
            var obj_taller = new List<Usuario>();

            try
            {
                using (var db = new BDModeloTaex())
                {
                    obj_taller = db.Usuario.Include("Personal_OBUN").Include("Docente").Include("Estudiante").ToList(); //Debe listar lo que hay en mi Tabla Usuario
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj_taller; //Muestra o retorna todos los objetos almacenados
        }

        //Metodo Buscar
        public List<Usuario> Buscar(string Criterio) //retorna una lista o colección del objetos
        {
            var obj_taller = new List<Usuario>();
            try
            {
                using (var db = new BDModeloTaex()) //ADO que creamos
                {
                    obj_taller = db.Usuario.Include("Personal_OBUN").Include("Docente").Include("Estudiante")
                                    .Where(x =>
                                                x.Nombre.Contains(Criterio) || //se puede buscar por docente porque hemos incluido la tabla
                                                x.Clave.Contains(Criterio)
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

        public Usuario Obtener(int id) //retornar un objeto
        {
            var obj_taller = new Usuario();

            try
            {
                using (var db = new BDModeloTaex())
                {
                    obj_taller = db.Usuario.Include("Personal_OBUN").Include("Docente").Include("Estudiante")
                                    .Where(x => x.ID_Usuario == id)
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
                    if (this.ID_Usuario > 0)
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



        public ResponseModel Acceder(string Usuario, string Password)
        {
            var rm = new ResponseModel();
            try
            {
                //ModelBD es el ADO QUE HEMOS CREADO
                using (var db = new BDModeloTaex())
                {
                    Password = HashHelper.MD5(Password);

                    var query = db.Usuario.Where(x => x.Nombre == Usuario)
                        .Where(x => x.Clave == Password)
                        .SingleOrDefault();

                    if (query != null)
                    {
                        SessionHelper.AddUserToSession(ID_Usuario.ToString());
                        rm.SetResponse(true);

                    }
                    else
                    {
                        rm.SetResponse(false, "Usuario y/o Password incorrectos ...");
                    }

                }
            }

            catch (Exception ex)
            { throw; }
            return rm;
        }


    }
}
