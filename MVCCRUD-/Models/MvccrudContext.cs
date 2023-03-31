using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVCCRUD_.Models;

public partial class MvccrudContext : DbContext
{
    public MvccrudContext()
    {
    }

    public MvccrudContext(DbContextOptions<MvccrudContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carrera> Carreras { get; set; }

    public virtual DbSet<Equipo> Equipos { get; set; }

    public virtual DbSet<EstadosEquipo> EstadosEquipos { get; set; }

    public virtual DbSet<EstadosReserva> EstadosReservas { get; set; }

    public virtual DbSet<Facultade> Facultades { get; set; }

    public virtual DbSet<TipoEquipo> TipoEquipos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            //        => optionsBuilder.UseSqlServer("Server=localhost; Database=MVCCRUD; Trusted_Connection=True; TrustServerCertificate=True;");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrera>(entity =>
        {
            entity.HasKey(e => e.CarreraId).HasName("PK__carreras__1F1EC700B6AE4783");

            entity.ToTable("carreras");

            entity.Property(e => e.CarreraId).HasColumnName("carrera_id");
            entity.Property(e => e.FacultadId).HasColumnName("facultad_id");
            entity.Property(e => e.NombreCarrera)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nombre_carrera");
        });

        modelBuilder.Entity<Equipo>(entity =>
        {
            entity.HasKey(e => e.IdMarcas).HasName("PK__Equipos__EB594FAD142F2369");

            entity.Property(e => e.IdMarcas).HasColumnName("Id_marcas");
            entity.Property(e => e.Estados)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NombreMarca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_marca");
        });

        modelBuilder.Entity<EstadosEquipo>(entity =>
        {
            entity.HasKey(e => e.IdEstadosEquipo).HasName("PK__estados___BE0FBCF9737AC80B");

            entity.ToTable("estados_equipo");

            entity.Property(e => e.IdEstadosEquipo).HasColumnName("id_estados_equipo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
        });

        modelBuilder.Entity<EstadosReserva>(entity =>
        {
            entity.HasKey(e => e.EstadoResId).HasName("PK__estados___5E7C248CC6A13319");

            entity.ToTable("estados_reserva");

            entity.Property(e => e.EstadoResId).HasColumnName("estado_res_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("estado");
        });

        modelBuilder.Entity<Facultade>(entity =>
        {
            entity.HasKey(e => e.FacultadId).HasName("PK__facultad__6407F1AECB309B0D");

            entity.ToTable("facultades");

            entity.Property(e => e.FacultadId).HasColumnName("facultad_id");
            entity.Property(e => e.NombreFacultad)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nombre_facultad");
        });

        modelBuilder.Entity<TipoEquipo>(entity =>
        {
            entity.HasKey(e => e.IdTipoEquipo).HasName("PK__tipo_equ__82617B32839F7D0C");

            entity.ToTable("tipo_equipo");

            entity.Property(e => e.IdTipoEquipo).HasColumnName("id_tipo_equipo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__usuarios__2ED7D2AF48295779");

            entity.ToTable("usuarios");

            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
            entity.Property(e => e.Carnet)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("carnet");
            entity.Property(e => e.CarreraId).HasColumnName("carrera_id");
            entity.Property(e => e.Documento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("documento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tipo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
