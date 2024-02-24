using System;
using System.Collections.Generic;
using BANCOEMPLEOJAC.MODELO;
using Microsoft.EntityFrameworkCore;

namespace BANCOEMPLEOJAC.REPOSITORIO.DBContext;

public partial class Bancoempleojac99Context : DbContext
{
    public Bancoempleojac99Context()
    {
    }

    public Bancoempleojac99Context(DbContextOptions<Bancoempleojac99Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrador> Administradors { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Empleador> Empleadors { get; set; }

    public virtual DbSet<Empleo> Empleos { get; set; }

    public virtual DbSet<EmpleoxEmpleado> EmpleoxEmpleados { get; set; }

    public virtual DbSet<Jac> Jacs { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Pais> Paises { get; set; }

    public virtual DbSet<PerfilCargo> PerfilCargos { get; set; }

    public virtual DbSet<PropuestaEmpleo> PropuestaEmpleos { get; set; }

    public virtual DbSet<PropuestaServicio> PropuestaServicios { get; set; }

    public virtual DbSet<Region> Regiones { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<TipoContrato> TipoContratos { get; set; }

    public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<ZonaVereda> ZonaVereda { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.ToTable("Administrador");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Jac).WithMany(p => p.Administradors)
                .HasForeignKey(d => d.JacId)
                .HasConstraintName("FK_Administrador_JAC");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Administradors)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK_Administrador_Usuario");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.Capital).HasMaxLength(100);
            entity.Property(e => e.CodigoPostal).HasMaxLength(100);
            entity.Property(e => e.IdPais).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(200);
            entity.Property(e => e.Observaciones).HasMaxLength(1000);

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Departamentos)
                .HasForeignKey(d => d.IdPais)
                .HasConstraintName("FK_Departamentos_Paises");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.ToTable("Empleado");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK_Empleado_Usuario");
        });

        modelBuilder.Entity<Empleador>(entity =>
        {
            entity.HasKey(e => e.IdEmpleador);

            entity.ToTable("Empleador");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Empleadors)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK_Empleador_Usuario");
        });

        modelBuilder.Entity<Empleo>(entity =>
        {
            entity.ToTable("Empleo");

            entity.Property(e => e.Compensacion).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FechaHoraActiva).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaHoraFin).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraInactiva).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraInicio).HasColumnType("datetime");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Empleos)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK_Empleo_Empleado");

            entity.HasOne(d => d.Empleador).WithMany(p => p.Empleos)
                .HasForeignKey(d => d.EmpleadorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empleo_Empleador");

            entity.HasOne(d => d.PerfilCargo).WithMany(p => p.Empleos)
                .HasForeignKey(d => d.PerfilCargoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empleo_PerfilCargo");
        });

        modelBuilder.Entity<EmpleoxEmpleado>(entity =>
        {
            entity.ToTable("EmpleoxEmpleado");

            entity.Property(e => e.FechaHoraFin).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraInicio).HasColumnType("datetime");

            entity.HasOne(d => d.Empleado).WithMany(p => p.EmpleoxEmpleados)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmpleoxEmpleado_Empleado");

            entity.HasOne(d => d.Empleo).WithMany(p => p.EmpleoxEmpleados)
                .HasForeignKey(d => d.EmpleoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmpleoxEmpleado_Empleo");
        });

        modelBuilder.Entity<Jac>(entity =>
        {
            entity.HasKey(e => e.IdJac);

            entity.ToTable("JAC");

            entity.Property(e => e.IdJac).HasColumnName("IdJAC");
            entity.Property(e => e.Delimitacion).IsUnicode(false);
            entity.Property(e => e.FechaRegistroIdaco)
                .HasColumnType("datetime")
                .HasColumnName("FechaRegistroIDACO");
            entity.Property(e => e.Foto).IsUnicode(false);
            entity.Property(e => e.IdZonaVereda).HasMaxLength(50);
            entity.Property(e => e.Nit).HasColumnName("NIT");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.NombreAdminLocal)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombrePresidente).HasMaxLength(100);
            entity.Property(e => e.Notas).IsUnicode(false);

            entity.HasOne(d => d.IdZonaVeredaNavigation).WithMany(p => p.Jacs)
                .HasForeignKey(d => d.IdZonaVereda)
                .HasConstraintName("FK_JAC_ZonaVereda");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.CodigoPostal).HasMaxLength(50);
            entity.Property(e => e.IdRegion).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.IdRegionNavigation).WithMany(p => p.Municipios)
                .HasForeignKey(d => d.IdRegion)
                .HasConstraintName("FK_Municipios_Regiones");
        });

        modelBuilder.Entity<Pais>(entity =>
        {
            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.Descripion).HasMaxLength(500);
            entity.Property(e => e.Nombre).HasMaxLength(200);
            entity.Property(e => e.Region).HasMaxLength(200);
        });

        modelBuilder.Entity<PerfilCargo>(entity =>
        {
            entity.HasKey(e => e.IdPerfilCargo);

            entity.ToTable("PerfilCargo");

            entity.Property(e => e.Compensacion).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.Notas).IsUnicode(false);
            entity.Property(e => e.Requisitos).IsUnicode(false);

            entity.HasOne(d => d.IdTipoContratoNavigation).WithMany(p => p.PerfilCargos)
                .HasForeignKey(d => d.IdTipoContrato)
                .HasConstraintName("FK_PerfilCargo_TipoContrato");

            entity.HasOne(d => d.Jac).WithMany(p => p.PerfilCargos)
                .HasForeignKey(d => d.JacId)
                .HasConstraintName("FK_PerfilCargo_JAC");
        });

        modelBuilder.Entity<PropuestaEmpleo>(entity =>
        {
            entity.ToTable("PropuestaEmpleo");

            entity.Property(e => e.Compensacion).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.FechaHoraAceptaEmpleador).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaHoraFin).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraInicio).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraReProponeEmpleador).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraRevisaEmpleador).HasColumnType("datetime");
            entity.Property(e => e.Observaciones).IsUnicode(false);
            entity.Property(e => e.Requisitos).IsUnicode(false);
            entity.Property(e => e.Ubicacion).IsUnicode(false);

            entity.HasOne(d => d.Empleado).WithMany(p => p.PropuestaEmpleos)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK_PropuestaEmpleo_Empleado");

            entity.HasOne(d => d.Empleo).WithMany(p => p.PropuestaEmpleos)
                .HasForeignKey(d => d.EmpleoId)
                .HasConstraintName("FK_PropuestaEmpleo_Empleo1");
        });

        modelBuilder.Entity<PropuestaServicio>(entity =>
        {
            entity.ToTable("PropuestaServicio");

            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraAcepta).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraReRepropone).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraRevisaPropuesta).HasColumnType("datetime");
            entity.Property(e => e.Foto).IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Observaciones).IsUnicode(false);
            entity.Property(e => e.Ubicacion).IsUnicode(false);
            entity.Property(e => e.ValorUnitario).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Empleado).WithMany(p => p.PropuestaServicios)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK_PropuestaServicio_Empleado");

            entity.HasOne(d => d.Empleador).WithMany(p => p.PropuestaServicios)
                .HasForeignKey(d => d.EmpleadorId)
                .HasConstraintName("FK_PropuestaServicio_Empleador");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.CodigoPostal).HasMaxLength(100);
            entity.Property(e => e.IdDepartamento).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(200);
            entity.Property(e => e.Observaciones).HasMaxLength(1000);

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Regiones)
                .HasForeignKey(d => d.IdDepartamento)
                .HasConstraintName("FK_Regiones_Departamentos");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.ToTable("Servicio");

            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Foto).IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Observaciones).IsUnicode(false);
            entity.Property(e => e.Ubicacion).IsUnicode(false);
            entity.Property(e => e.ValorUnitario).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK_Servicio_Empleado");

            entity.HasOne(d => d.Empleador).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.EmpleadorId)
                .HasConstraintName("FK_Servicio_Empleador");

            entity.HasOne(d => d.PerfilCargo).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.PerfilCargoId)
                .HasConstraintName("FK_Servicio_PerfilCargo");
        });

        modelBuilder.Entity<TipoContrato>(entity =>
        {
            entity.HasKey(e => e.IdTipoContrato);

            entity.ToTable("TipoContrato");

            entity.Property(e => e.Descripción)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoUsuario>(entity =>
        {
            entity.HasKey(e => e.IdRol);

            entity.ToTable("TipoUsuario");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("Usuario");

            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Celular)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Clave)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Foto).IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Jac).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.JacId)
                .HasConstraintName("FK_Usuario_JAC");

            entity.HasOne(d => d.RolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Rol)
                .HasConstraintName("FK_Usuario_TipoUsuario");
        });

        modelBuilder.Entity<ZonaVereda>(entity =>
        {
            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.IdMunicipio).HasMaxLength(50);
            entity.Property(e => e.Latitud).HasMaxLength(50);
            entity.Property(e => e.Longitud).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(200);
            entity.Property(e => e.Observaciones).HasMaxLength(1000);
            entity.Property(e => e.Ubicacion).HasMaxLength(2000);

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.ZonaVereda)
                .HasForeignKey(d => d.IdMunicipio)
                .HasConstraintName("FK_ZonaVereda_Municipios");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
