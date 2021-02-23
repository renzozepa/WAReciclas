namespace WAReciclas.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Reciclas : DbContext
    {
        public Reciclas()
            : base("name=Reciclas")
        {
        }

        public virtual DbSet<ESTADO_RECOJO> ESTADO_RECOJO { get; set; }
        public virtual DbSet<HORARIO> HORARIO { get; set; }
        public virtual DbSet<PERFIL> PERFIL { get; set; }
        public virtual DbSet<RECOJO> RECOJO { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
        public virtual DbSet<HORARIO_DETALLE> HORARIO_DETALLE { get; set; }
        public virtual DbSet<RECOJO_DETALLE> RECOJO_DETALLE { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ESTADO_RECOJO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<HORARIO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<PERFIL>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<RECOJO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<RECOJO>()
                .Property(e => e.TOKEN_RECOJO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.USUARIO1)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.CLAVE)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.DIRECCION)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.LATITUD)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.LONGITUD)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.TOKEN)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
               .Property(e => e.CELULAR)
               .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
               .Property(e => e.ZIPCODE)
               .IsUnicode(false);

            modelBuilder.Entity<HORARIO_DETALLE>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<HORARIO_DETALLE>()
                .Property(e => e.HORA_INICIO)
                .IsUnicode(false);

            modelBuilder.Entity<HORARIO_DETALLE>()
                .Property(e => e.HORA_FIN)
                .IsUnicode(false);

            modelBuilder.Entity<RECOJO_DETALLE>()
                .Property(e => e.TOKEN_RECOJO_DETALLE)
                .IsUnicode(false);

            modelBuilder.Entity<RECOJO_DETALLE>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<RECOJO_DETALLE>()
                .Property(e => e.CANTIDAD)
                .HasPrecision(18, 3);

            modelBuilder.Entity<RECOJO_DETALLE>()
                .Property(e => e.PESO)
                .HasPrecision(18, 3);
        }
    }
}
