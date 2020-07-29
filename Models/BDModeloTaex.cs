namespace SIGEM_TAEX.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BDModeloTaex : DbContext
    {
        public BDModeloTaex()
            : base("name=BDModeloTaex")
        {
        }

        public virtual DbSet<Asistencia> Asistencia { get; set; }
        public virtual DbSet<Docente> Docente { get; set; }
        public virtual DbSet<Escuela_Profesional> Escuela_Profesional { get; set; }
        public virtual DbSet<Estudiante> Estudiante { get; set; }
        public virtual DbSet<Horario> Horario { get; set; }
        public virtual DbSet<Lugar> Lugar { get; set; }
        public virtual DbSet<Matricula> Matricula { get; set; }
        public virtual DbSet<Nota> Nota { get; set; }
        public virtual DbSet<Periodo> Periodo { get; set; }
        public virtual DbSet<Personal_OBUN> Personal_OBUN { get; set; }
        public virtual DbSet<Taller> Taller { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asistencia>()
                .Property(e => e.Asistencia1)
                .IsUnicode(false);

            modelBuilder.Entity<Asistencia>()
                .Property(e => e.Tardanza)
                .IsUnicode(false);

            modelBuilder.Entity<Asistencia>()
                .Property(e => e.Inasistencia)
                .IsUnicode(false);

            modelBuilder.Entity<Docente>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Docente>()
                .Property(e => e.Apellido_Paterno)
                .IsUnicode(false);

            modelBuilder.Entity<Docente>()
                .Property(e => e.Apellido_Materno)
                .IsUnicode(false);

            modelBuilder.Entity<Docente>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Docente>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Docente>()
                .Property(e => e.Estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Docente>()
                .HasMany(e => e.Taller)
                .WithRequired(e => e.Docente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Docente>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.Docente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Escuela_Profesional>()
                .Property(e => e.Nombre_Escuela)
                .IsUnicode(false);

            modelBuilder.Entity<Escuela_Profesional>()
                .Property(e => e.Facultad)
                .IsUnicode(false);

            modelBuilder.Entity<Escuela_Profesional>()
                .HasMany(e => e.Estudiante)
                .WithRequired(e => e.Escuela_Profesional)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.Tipo_Identificacion)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.Apellido_Paterno)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.Apellido_Materno)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.Dirección)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.Sexo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.Estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .HasMany(e => e.Asistencia)
                .WithRequired(e => e.Estudiante)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estudiante>()
                .HasMany(e => e.Matricula)
                .WithRequired(e => e.Estudiante)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estudiante>()
                .HasMany(e => e.Nota)
                .WithRequired(e => e.Estudiante)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estudiante>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.Estudiante)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Horario>()
                .Property(e => e.Dia)
                .IsUnicode(false);

            modelBuilder.Entity<Horario>()
                .Property(e => e.Hora)
                .IsUnicode(false);

            modelBuilder.Entity<Horario>()
                .HasMany(e => e.Taller)
                .WithRequired(e => e.Horario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lugar>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Lugar>()
                .Property(e => e.Referencia)
                .IsUnicode(false);

            modelBuilder.Entity<Lugar>()
                .HasMany(e => e.Taller)
                .WithRequired(e => e.Lugar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Matricula>()
                .Property(e => e.Costo_Taller)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Nota>()
                .Property(e => e.Evaluacion1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Nota>()
                .Property(e => e.Evaluacion2)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Nota>()
                .Property(e => e.Evaluacion3)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Nota>()
                .Property(e => e.Promedio)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Periodo>()
                .Property(e => e.Nombre_Periodo)
                .IsUnicode(false);

            modelBuilder.Entity<Periodo>()
                .HasMany(e => e.Matricula)
                .WithRequired(e => e.Periodo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Periodo>()
                .HasMany(e => e.Nota)
                .WithRequired(e => e.Periodo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Personal_OBUN>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Personal_OBUN>()
                .Property(e => e.Apellido_Paterno)
                .IsUnicode(false);

            modelBuilder.Entity<Personal_OBUN>()
                .Property(e => e.Apellido_Materno)
                .IsUnicode(false);

            modelBuilder.Entity<Personal_OBUN>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Personal_OBUN>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Personal_OBUN>()
                .Property(e => e.Estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Personal_OBUN>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.Personal_OBUN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Taller>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Taller>()
                .Property(e => e.Categoria)
                .IsUnicode(false);

            modelBuilder.Entity<Taller>()
                .Property(e => e.Estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Taller>()
                .HasMany(e => e.Asistencia)
                .WithRequired(e => e.Taller)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Taller>()
                .HasMany(e => e.Matricula)
                .WithRequired(e => e.Taller)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Taller>()
                .HasMany(e => e.Nota)
                .WithRequired(e => e.Taller)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Clave)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nivel)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Avatar)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Estado)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
