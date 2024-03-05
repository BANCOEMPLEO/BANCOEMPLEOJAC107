using System;
using System.Collections.Generic;
using BANCOEMPLEOJAC.Modelo;
using Microsoft.EntityFrameworkCore;

namespace BANCOEMPLEOJAC.Repositorio.DBContext;

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

    public virtual DbSet<AsambleaReuniones> AsambleaReuniones { get; set; }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<ComisionesTrabajo> ComisionesTrabajos { get; set; }

    public virtual DbSet<Contrato> Contratos { get; set; }

    public virtual DbSet<CoordinadorComisionEmpresarial> CoordinadorComisionEmpresarials { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<DetallePropuesta> DetallePropuesta { get; set; }

    public virtual DbSet<Dignatario> Dignatarios { get; set; }

    public virtual DbSet<DivisionActividadEconomica> DivisionActividadEconomicas { get; set; }

    public virtual DbSet<Empleo> Empleos { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Fiscal> Fiscals { get; set; }

    public virtual DbSet<GrupoActividadEconomica> GrupoActividadEconomicas { get; set; }

    public virtual DbSet<Jac> Jacs { get; set; }

    public virtual DbSet<JuntaDirectivaReuniones> JuntaDirectivaReuniones { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Pais> Pais { get; set; }

    public virtual DbSet<PerfilCargo> PerfilCargos { get; set; }

    public virtual DbSet<PropuestaEmpleo> PropuestaEmpleos { get; set; }

    public virtual DbSet<PropuestaServicio> PropuestaServicios { get; set; }

    public virtual DbSet<Regiones> Regiones { get; set; }

    public virtual DbSet<RepresentantesAsojuntas> RepresentantesAsojuntas { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<SeccionActividadEconomica> SeccionActividadEconomicas { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<TipoAsamblea> TipoAsambleas { get; set; }

    public virtual DbSet<TipoContrato> TipoContratos { get; set; }

    public virtual DbSet<TipoJuntaDirectiva> TipoJuntaDirectivas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<ZonaVereda> ZonaVereda { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

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

        modelBuilder.Entity<AsambleaReuniones>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Asamblea");

            entity.Property(e => e.CalidadQuienConvoca)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContenidoActa).IsUnicode(false);
            entity.Property(e => e.FechaHoraConvocatoria).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraDesFijacionAvisos).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraFijacionAvisos).HasColumnType("datetime");
            entity.Property(e => e.Jacid).HasColumnName("JACId");
            entity.Property(e => e.NombreQuienConvoca)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Observaciones).IsUnicode(false);
            entity.Property(e => e.OrdenDelDia).IsUnicode(false);

            entity.HasOne(d => d.Jac).WithMany(p => p.AsambleaReuniones)
                .HasForeignKey(d => d.Jacid)
                .HasConstraintName("FK_Asamblea_JAC");

            entity.HasOne(d => d.TipoAsambleaNavigation).WithMany(p => p.AsambleaReuniones)
                .HasForeignKey(d => d.TipoAsamblea)
                .HasConstraintName("FK_Asamblea_TipoAsamblea");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria);

            entity.Property(e => e.Caracteristicas)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FechaHoraCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Observaciones).IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.ActividadEconomica).WithMany(p => p.Categoria)
                .HasForeignKey(d => d.ActividadEconomicaId)
                .HasConstraintName("FK_Categoria_ActividadEconomica");

            entity.HasOne(d => d.TipoContrato).WithMany(p => p.Categoria)
                .HasForeignKey(d => d.TipoContratoId)
                .HasConstraintName("FK_Categoria_TipoContrato");
        });

        modelBuilder.Entity<ComisionesTrabajo>(entity =>
        {
            entity.ToTable("ComisionesTrabajo");

            entity.Property(e => e.Funciones).IsUnicode(false);
            entity.Property(e => e.NombreComisión)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Observaciones).IsUnicode(false);

            entity.HasOne(d => d.Coordinador).WithMany(p => p.ComisionesTrabajoCoordinadors)
                .HasForeignKey(d => d.CoordinadorId)
                .HasConstraintName("FK_ComisionesTrabajo_Usuario");

            entity.HasOne(d => d.Suplente).WithMany(p => p.ComisionesTrabajoSuplentes)
                .HasForeignKey(d => d.SuplenteId)
                .HasConstraintName("FK_ComisionesTrabajo_Usuario1");
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

        modelBuilder.Entity<CoordinadorComisionEmpresarial>(entity =>
        {
            entity.ToTable("CoordinadorComisionEmpresarial");

            entity.Property(e => e.Funciones).IsUnicode(false);
            entity.Property(e => e.Jacid).HasColumnName("JACId");
            entity.Property(e => e.Observaciones).IsUnicode(false);

            entity.HasOne(d => d.Coordinador).WithMany(p => p.CoordinadorComisionEmpresarialCoordinadors)
                .HasForeignKey(d => d.CoordinadorId)
                .HasConstraintName("FK_CoordinadorComisionEmpresarial_Usuario");

            entity.HasOne(d => d.Jac).WithMany(p => p.CoordinadorComisionEmpresarials)
                .HasForeignKey(d => d.Jacid)
                .HasConstraintName("FK_CoordinadorComisionEmpresarial_JAC");

            entity.HasOne(d => d.Suplente).WithMany(p => p.CoordinadorComisionEmpresarialSuplentes)
                .HasForeignKey(d => d.SuplenteId)
                .HasConstraintName("FK_CoordinadorComisionEmpresarial_Usuario1");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK_Departamentos");

            entity.ToTable("Departamento");

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

            entity.Property(e => e.FechaHoraCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Observaciones).IsUnicode(false);
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

        modelBuilder.Entity<Dignatario>(entity =>
        {
            entity.Property(e => e.FuncionesPresidente).IsUnicode(false);
            entity.Property(e => e.FuncionesSecretario).IsUnicode(false);
            entity.Property(e => e.FuncionesTesorero).IsUnicode(false);
            entity.Property(e => e.FuncionesVicepresidente).IsUnicode(false);
            entity.Property(e => e.Jacid).HasColumnName("JACId");
            entity.Property(e => e.Observaciones).IsUnicode(false);

            entity.HasOne(d => d.Jac).WithMany(p => p.Dignatarios)
                .HasForeignKey(d => d.Jacid)
                .HasConstraintName("FK_Dignatarios_JAC");

            entity.HasOne(d => d.Presidente).WithMany(p => p.DignatarioPresidentes)
                .HasForeignKey(d => d.PresidenteId)
                .HasConstraintName("FK_Dignatarios_Usuario");

            entity.HasOne(d => d.Secretario).WithMany(p => p.DignatarioSecretarios)
                .HasForeignKey(d => d.SecretarioId)
                .HasConstraintName("FK_Dignatarios_Usuario3");

            entity.HasOne(d => d.Tesosrero).WithMany(p => p.DignatarioTesosreros)
                .HasForeignKey(d => d.TesosreroId)
                .HasConstraintName("FK_Dignatarios_Usuario2");

            entity.HasOne(d => d.Vicepresidente).WithMany(p => p.DignatarioVicepresidentes)
                .HasForeignKey(d => d.VicepresidenteId)
                .HasConstraintName("FK_Dignatarios_Usuario1");
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

        modelBuilder.Entity<Empleo>(entity =>
        {
            entity.HasKey(e => e.IdEmpleo);

            entity.ToTable("Empleo");

            entity.Property(e => e.Cantidad).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaHoraActiva).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaHoraFin).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraInactiva).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraInicio).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.PrecioOferta).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Empleado).WithMany(p => p.EmpleoEmpleados)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK_Empleo_Usuario1");

            entity.HasOne(d => d.Empleador).WithMany(p => p.EmpleoEmpleadors)
                .HasForeignKey(d => d.EmpleadorId)
                .HasConstraintName("FK_Empleo_Usuario");

            entity.HasOne(d => d.PerfilCargo).WithMany(p => p.Empleos)
                .HasForeignKey(d => d.PerfilCargoId)
                .HasConstraintName("FK_Empleo_PerfilCargo");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.ToTable("Empresa");

            entity.Property(e => e.Barrio)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CamaraComercio)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GerenteGeneral)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Jacid).HasColumnName("JACId");
            entity.Property(e => e.Nit).HasColumnName("NIT");
            entity.Property(e => e.Observaciones).IsUnicode(false);
            entity.Property(e => e.RegistroMercantil)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RozonSocial)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Jac).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.Jacid)
                .HasConstraintName("FK_Empresa_JAC");
        });

        modelBuilder.Entity<Fiscal>(entity =>
        {
            entity.ToTable("Fiscal");

            entity.Property(e => e.Funciones).IsUnicode(false);
            entity.Property(e => e.Jacid).HasColumnName("JACId");
            entity.Property(e => e.Observaciones).IsUnicode(false);

            entity.HasOne(d => d.FiscalNavigation).WithMany(p => p.FiscalFiscalNavigations)
                .HasForeignKey(d => d.FiscalId)
                .HasConstraintName("FK_Fiscal_Usuario");

            entity.HasOne(d => d.Jac).WithMany(p => p.Fiscals)
                .HasForeignKey(d => d.Jacid)
                .HasConstraintName("FK_Fiscal_JAC");

            entity.HasOne(d => d.Suplente).WithMany(p => p.FiscalSuplentes)
                .HasForeignKey(d => d.SuplenteId)
                .HasConstraintName("FK_Fiscal_Usuario1");
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
            entity.Property(e => e.FechaHoraCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaRegistroPersoneriaJuridica).HasColumnType("datetime");
            entity.Property(e => e.Foto).IsUnicode(false);
            entity.Property(e => e.IdZonaVereda).HasMaxLength(50);
            entity.Property(e => e.Nit).HasColumnName("NIT");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.NombreAdminLocal)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Observaciones).IsUnicode(false);

            entity.HasOne(d => d.IdZonaVeredaNavigation).WithMany(p => p.Jacs)
                .HasForeignKey(d => d.IdZonaVereda)
                .HasConstraintName("FK_JAC_ZonaVereda");

            entity.HasMany(d => d.ComisionTrabajos).WithMany(p => p.Jacs)
                .UsingEntity<Dictionary<string, object>>(
                    "CoordinadoresComisionesTrabajoXjac",
                    r => r.HasOne<ComisionesTrabajo>().WithMany()
                        .HasForeignKey("ComisionTrabajoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CoordinadoresComisionesTrabajoXJAC_ComisionesTrabajo"),
                    l => l.HasOne<Jac>().WithMany()
                        .HasForeignKey("Jacid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CoordinadoresComisionesTrabajoXJAC_JAC"),
                    j =>
                    {
                        j.HasKey("Jacid", "ComisionTrabajoId");
                        j.ToTable("CoordinadoresComisionesTrabajoXJAC");
                        j.IndexerProperty<int>("Jacid").HasColumnName("JACId");
                    });
        });

        modelBuilder.Entity<JuntaDirectivaReuniones>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_JuntaDirectiva");

            entity.Property(e => e.ContenidoActa).IsUnicode(false);
            entity.Property(e => e.FechaHoraAviso).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraComvocatoria).HasColumnType("datetime");
            entity.Property(e => e.Jacid).HasColumnName("JACId");
            entity.Property(e => e.Observaciones).IsUnicode(false);
            entity.Property(e => e.OrdenDelDia).IsUnicode(false);

            entity.HasOne(d => d.Jac).WithMany(p => p.JuntaDirectivaReuniones)
                .HasForeignKey(d => d.Jacid)
                .HasConstraintName("FK_JuntaDirectiva_JAC");

            entity.HasOne(d => d.TipoJuntaNavigation).WithMany(p => p.JuntaDirectivaReuniones)
                .HasForeignKey(d => d.TipoJunta)
                .HasConstraintName("FK_JuntaDirectiva_TipoJuntaDirectiva");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.IdMunicipio).HasName("PK_Municipios");

            entity.ToTable("Municipio");

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
            entity.HasKey(e => e.IdPais).HasName("PK_Paises");

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
            entity.Property(e => e.FechaHoraCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Observaciones).IsUnicode(false);
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
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Observaciones).IsUnicode(false);
            entity.Property(e => e.Requisitos).IsUnicode(false);
            entity.Property(e => e.Ubicacion).IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Empleado).WithMany(p => p.PropuestaEmpleoEmpleados)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK_PropuestaEmpleo_Usuario1");

            entity.HasOne(d => d.Empleador).WithMany(p => p.PropuestaEmpleoEmpleadors)
                .HasForeignKey(d => d.EmpleadorId)
                .HasConstraintName("FK_PropuestaEmpleo_Usuario");

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

            entity.Property(e => e.Caracteristicas).IsUnicode(false);
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

            entity.HasOne(d => d.Empleado).WithMany(p => p.PropuestaServicioEmpleados)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK_PropuestaServicio_Usuario");

            entity.HasOne(d => d.Empleador).WithMany(p => p.PropuestaServicioEmpleadors)
                .HasForeignKey(d => d.EmpleadorId)
                .HasConstraintName("FK_PropuestaServicio_Usuario1");

            entity.HasOne(d => d.PropuestaServicioAnterior).WithMany(p => p.InversePropuestaServicioAnterior)
                .HasForeignKey(d => d.PropuestaServicioAnteriorId)
                .HasConstraintName("FK_PropuestaServicio_PropuestaServicio");

            entity.HasOne(d => d.Servicio).WithMany(p => p.PropuestaServicios)
                .HasForeignKey(d => d.ServicioId)
                .HasConstraintName("FK_PropuestaServicio_Servicio");
        });

        modelBuilder.Entity<Regiones>(entity =>
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

        modelBuilder.Entity<RepresentantesAsojuntas>(entity =>
        {
            entity.ToTable("RepresentantesASOJUNTAS");

            entity.Property(e => e.Funciones).IsUnicode(false);
            entity.Property(e => e.Jacid).HasColumnName("JACId");
            entity.Property(e => e.Observaciones).IsUnicode(false);

            entity.HasOne(d => d.Jac).WithMany(p => p.RepresentantesAsojunta)
                .HasForeignKey(d => d.Jacid)
                .HasConstraintName("FK_RepresentantesASOJUNTAS_JAC");

            entity.HasOne(d => d.Representante1Navigation).WithMany(p => p.RepresentantesAsojuntaRepresentante1Navigations)
                .HasForeignKey(d => d.Representante1)
                .HasConstraintName("FK_RepresentantesASOJUNTAS_Usuario");

            entity.HasOne(d => d.Representante2Navigation).WithMany(p => p.RepresentantesAsojuntaRepresentante2Navigations)
                .HasForeignKey(d => d.Representante2)
                .HasConstraintName("FK_RepresentantesASOJUNTAS_Usuario1");

            entity.HasOne(d => d.Representante3Navigation).WithMany(p => p.RepresentantesAsojuntaRepresentante3Navigations)
                .HasForeignKey(d => d.Representante3)
                .HasConstraintName("FK_RepresentantesASOJUNTAS_Usuario2");
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

            entity.Property(e => e.Caracteristicas).IsUnicode(false);
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

            entity.HasOne(d => d.Categoria).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("FK_Servicio_Categoria");

            entity.HasOne(d => d.Empleado).WithMany(p => p.ServicioEmpleados)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK_Servicio_Usuario");

            entity.HasOne(d => d.Empleador).WithMany(p => p.ServicioEmpleadors)
                .HasForeignKey(d => d.EmpleadorId)
                .HasConstraintName("FK_Servicio_Usuario1");
        });

        modelBuilder.Entity<TipoAsamblea>(entity =>
        {
            entity.ToTable("TipoAsamblea");

            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
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

        modelBuilder.Entity<TipoJuntaDirectiva>(entity =>
        {
            entity.ToTable("TipoJuntaDirectiva");

            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("Usuario");

            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Celular)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Clave).IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaHoraCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.Foto).IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Observaciones).IsUnicode(false);
            entity.Property(e => e.Redes).IsUnicode(false);
            entity.Property(e => e.Rol).HasDefaultValueSql("((5))");

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
            entity.Property(e => e.FechaHoraCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
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
