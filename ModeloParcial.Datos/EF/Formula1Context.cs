using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ModeloParcial.Datos.EF
{
    public partial class Formula1Context : DbContext
    {
        public Formula1Context()
        {
        }

        public Formula1Context(DbContextOptions<Formula1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Escuderium> Escuderia { get; set; } = null!;
        public virtual DbSet<Piloto> Pilotos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-OSNAGHI\\SQLEXPRESS;Database=Formula1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Escuderium>(entity =>
            {
                entity.HasKey(e => e.IdEscuderia);

                entity.Property(e => e.NombreEscuderia).HasMaxLength(50);
            });

            modelBuilder.Entity<Piloto>(entity =>
            {
                entity.HasKey(e => e.IdPiloto);

                entity.ToTable("Piloto");

                entity.Property(e => e.NombrePiloto).HasMaxLength(50);

                entity.HasOne(d => d.IdEscuderiaNavigation)
                    .WithMany(p => p.Pilotos)
                    .HasForeignKey(d => d.IdEscuderia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Piloto_Escuderia");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
