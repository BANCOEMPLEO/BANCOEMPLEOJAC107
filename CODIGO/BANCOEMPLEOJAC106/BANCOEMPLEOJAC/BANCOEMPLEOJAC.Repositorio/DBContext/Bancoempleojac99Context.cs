﻿using System;
using System.Collections.Generic;
using BANCOEMPLEOJAC.Modelo;
using Microsoft.EntityFrameworkCore;

namespace BANCOEMPLEOJAC.Repositorio;

public partial class Bancoempleojac99Context : DbContext
{
    public Bancoempleojac99Context()
    {
    }

    public Bancoempleojac99Context(DbContextOptions<Bancoempleojac99Context> options)
        : base(options)
    {
    }

    public virtual DbSet<ActividadEconomica> ActividadEconomicas { get; set; }

    public virtual DbSet<Administrador> Administradors { get; set; }

    public virtual DbSet<Contrato> Contratos { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<DetallePropuesta> DetallePropuesta { get; set; }

    public virtual DbSet<DivisionActividadEconomica> DivisionActividadEconomicas { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Empleador> Empleadors { get; set; }

    public virtual DbSet<Empleo> Empleos { get; set; }

    public virtual DbSet<GrupoActividadEconomica> GrupoActividadEconomicas { get; set; }

    public virtual DbSet<Jac> Jacs { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Pais> Paises { get; set; }

    public virtual DbSet<PerfilCargo> PerfilCargos { get; set; }

    public virtual DbSet<PropuestaEmpleo> PropuestaEmpleos { get; set; }

    public virtual DbSet<PropuestaServicio> PropuestaServicios { get; set; }

    public virtual DbSet<Region> Regiones { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<SeccionActividadEconomica> SeccionActividadEconomicas { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<TipoContrato> TipoContratos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<ZonaVereda> ZonaVereda { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){ }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActividadEconomica>(entity =>
        {
            entity.HasKey(e => e.IdActividad).HasName("PK_ActividadesEconomicas");

            entity.ToTable("ActividadEconomica");

            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.Detalle).IsUnicode(false);
            entity.Property(e => e.IdClase)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.IdDivision)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.IdGrupo)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.IdSeccion)
                .HasMaxLength(2)
                .IsUnicode(false);

            entity.HasOne(d => d.IdDivisionNavigation).WithMany(p => p.ActividadEconomicas)
                .HasForeignKey(d => d.IdDivision)
                .HasConstraintName("FK_ActividadEconomica_DivisionActividadEconomica");

            entity.HasOne(d => d.IdGrupoNavigation).WithMany(p => p.ActividadEconomicas)
                .HasForeignKey(d => d.IdGrupo)
                .HasConstraintName("FK_ActividadEconomica_GrupoActividadEconomica");

            entity.HasOne(d => d.IdSeccionNavigation).WithMany(p => p.ActividadEconomicas)
                .HasForeignKey(d => d.IdSeccion)
                .HasConstraintName("FK_ActividadEconomica_SeccionActividadEconomica");
        });

        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.HasKey(e => e.IdAdministrador);

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

        modelBuilder.Entity<Contrato>(entity =>
        {
            entity.HasKey(e => e.IdContrato);

            entity.ToTable("Contrato");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento);

            entity.Property(e => e.IdDepartamento).HasMaxLength(50);
            entity.Property(e => e.Capital).HasMaxLength(100);
            entity.Property(e => e.CodigoPostal).HasMaxLength(100);
            entity.Property(e => e.IdPais).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(200);
            entity.Property(e => e.Observaciones).HasMaxLength(1000);

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Departamentos)
                .HasForeignKey(d => d.IdPais)
                .HasConstraintName("FK_Departamentos_Paises");
        });

        modelBuilder.Entity<DetallePropuesta>(entity =>
        {
            entity.HasKey(e => e.IdDetallePropuesta);

            entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Contrato).WithMany(p => p.DetallePropuesta)
                .HasForeignKey(d => d.ContratoId)
                .HasConstraintName("FK_DetallePropuesta_Contrato");

            entity.HasOne(d => d.DetallePropuestaAnterior).WithMany(p => p.InverseDetallePropuestaAnterior)
                .HasForeignKey(d => d.DetallePropuestaAnteriorId)
                .HasConstraintName("FK_DetallePropuesta_DetallePropuesta");

            entity.HasOne(d => d.PropuestaEmpleo).WithMany(p => p.DetallePropuesta)
                .HasForeignKey(d => d.PropuestaEmpleoId)
                .HasConstraintName("FK_DetallePropuesta_PropuestaEmpleo");

            entity.HasOne(d => d.PropuestaServicio).WithMany(p => p.DetallePropuesta)
                .HasForeignKey(d => d.PropuestaServicioId)
                .HasConstraintName("FK_DetallePropuesta_PropuestaServicio");
        });

        modelBuilder.Entity<DivisionActividadEconomica>(entity =>
        {
            entity.HasKey(e => e.IdDivision);

            entity.ToTable("DivisionActividadEconomica");

            entity.Property(e => e.IdDivision)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion).IsUnicode(false);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado);

            entity.ToTable("Empleado");

            entity.Property(e => e.Observaciones).IsUnicode(false);
            entity.Property(e => e.Vacante).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK_Empleado_Usuario");
        });

        modelBuilder.Entity<Empleador>(entity =>
        {
            entity.HasKey(e => e.IdEmpleador);

            entity.ToTable("Empleador");

            entity.Property(e => e.Contratando).HasDefaultValueSql("((0))");
            entity.Property(e => e.Observaciones).IsUnicode(false);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Empleadors)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK_Empleador_Usuario");
        });

        modelBuilder.Entity<Empleo>(entity =>
        {
            entity.HasKey(e => e.IdEmpleo);

            entity.ToTable("Empleo");

            entity.Property(e => e.FechaHoraActiva).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaHoraFin).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraInactiva).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraInicio).HasColumnType("datetime");
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PrecioOferta)
                .HasMaxLength(10)
                .IsFixedLength();

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

        modelBuilder.Entity<GrupoActividadEconomica>(entity =>
        {
            entity.HasKey(e => e.IdGrupo);

            entity.ToTable("GrupoActividadEconomica");

            entity.Property(e => e.IdGrupo)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Descripción).IsUnicode(false);
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
            entity.HasKey(e => e.IdMunicipio);

            entity.Property(e => e.IdMunicipio).HasMaxLength(50);
            entity.Property(e => e.CodigoPostal).HasMaxLength(50);
            entity.Property(e => e.IdRegion).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.IdRegionNavigation).WithMany(p => p.Municipios)
                .HasForeignKey(d => d.IdRegion)
                .HasConstraintName("FK_Municipios_Regiones");
        });

        modelBuilder.Entity<Pais>(entity =>
        {
            entity.HasKey(e => e.IdPais);

            entity.Property(e => e.IdPais).HasMaxLength(50);
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

            entity.HasOne(d => d.IdActividadEconomicaNavigation).WithMany(p => p.PerfilCargos)
                .HasForeignKey(d => d.IdActividadEconomica)
                .HasConstraintName("FK_PerfilCargo_ActividadEconomica");

            entity.HasOne(d => d.IdTipoContratoNavigation).WithMany(p => p.PerfilCargos)
                .HasForeignKey(d => d.IdTipoContrato)
                .HasConstraintName("FK_PerfilCargo_TipoContrato");

            entity.HasOne(d => d.Jac).WithMany(p => p.PerfilCargos)
                .HasForeignKey(d => d.JacId)
                .HasConstraintName("FK_PerfilCargo_JAC");
        });

        modelBuilder.Entity<PropuestaEmpleo>(entity =>
        {
            entity.HasKey(e => e.IdPropuestaEmpleo);

            entity.ToTable("PropuestaEmpleo");

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
            entity.Property(e => e.Valor).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Empleado).WithMany(p => p.PropuestaEmpleos)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK_PropuestaEmpleo_Empleado");

            entity.HasOne(d => d.Empleo).WithMany(p => p.PropuestaEmpleos)
                .HasForeignKey(d => d.EmpleoId)
                .HasConstraintName("FK_PropuestaEmpleo_Empleo1");

            entity.HasOne(d => d.PropuestaEmpleoAnterior).WithMany(p => p.InversePropuestaEmpleoAnterior)
                .HasForeignKey(d => d.PropuestaEmpleoAnteriorId)
                .HasConstraintName("FK_PropuestaEmpleo_PropuestaEmpleo");
        });

        modelBuilder.Entity<PropuestaServicio>(entity =>
        {
            entity.HasKey(e => e.IdPropuestaServicio);

            entity.ToTable("PropuestaServicio");

            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.FechaHoraAcepta).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraReRepropone).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraRevisaPropuesta).HasColumnType("datetime");
            entity.Property(e => e.Foto).IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Observaciones).IsUnicode(false);
            entity.Property(e => e.Ubicacion).IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Empleado).WithMany(p => p.PropuestaServicios)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK_PropuestaServicio_Empleado");

            entity.HasOne(d => d.Empleador).WithMany(p => p.PropuestaServicios)
                .HasForeignKey(d => d.EmpleadorId)
                .HasConstraintName("FK_PropuestaServicio_Empleador");

            entity.HasOne(d => d.PropuestaServicioAnterior).WithMany(p => p.InversePropuestaServicioAnterior)
                .HasForeignKey(d => d.PropuestaServicioAnteriorId)
                .HasConstraintName("FK_PropuestaServicio_PropuestaServicio");

            entity.HasOne(d => d.Servicio).WithMany(p => p.PropuestaServicios)
                .HasForeignKey(d => d.ServicioId)
                .HasConstraintName("FK_PropuestaServicio_Servicio");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.IdRegion);

            entity.Property(e => e.IdRegion).HasMaxLength(50);
            entity.Property(e => e.CodigoPostal).HasMaxLength(100);
            entity.Property(e => e.IdDepartamento).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(200);
            entity.Property(e => e.Observaciones).HasMaxLength(1000);

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Regiones)
                .HasForeignKey(d => d.IdDepartamento)
                .HasConstraintName("FK_Regiones_Departamentos");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK_TipoUsuario");

            entity.ToTable("Rol");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SeccionActividadEconomica>(entity =>
        {
            entity.HasKey(e => e.IdSeccion).HasName("PK_SeccionesActividadEconomica");

            entity.ToTable("SeccionActividadEconomica");

            entity.Property(e => e.IdSeccion)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion).IsUnicode(false);
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio);

            entity.ToTable("Servicio");

            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.FechaHoraCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Foto).IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Observaciones).IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.PrecioOferta).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Ubicacion).IsUnicode(false);

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
            entity.Property(e => e.Clave).IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaHoraCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.Foto).IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Observaciones).IsUnicode(false);
            entity.Property(e => e.Redes).IsUnicode(false);

            entity.HasOne(d => d.Jac).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.JacId)
                .HasConstraintName("FK_Usuario_JAC");

            entity.HasOne(d => d.RolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Rol)
                .HasConstraintName("FK_Usuario_TipoUsuario");
        });

        modelBuilder.Entity<ZonaVereda>(entity =>
        {
            entity.HasKey(e => e.IdzonaVereda);

            entity.Property(e => e.IdzonaVereda).HasMaxLength(50);
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