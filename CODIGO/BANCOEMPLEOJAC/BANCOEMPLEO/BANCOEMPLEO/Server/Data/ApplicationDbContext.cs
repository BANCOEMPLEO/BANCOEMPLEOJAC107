using BANCOEMPLEO.Server.Models;
using BANCOEMPLEO.Shared;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace BANCOEMPLEO.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<Empleo> Empleo { get; set; }
        public DbSet<Empleador> Empleador { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Servicio> Servicio { get; set; }

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
    }
}