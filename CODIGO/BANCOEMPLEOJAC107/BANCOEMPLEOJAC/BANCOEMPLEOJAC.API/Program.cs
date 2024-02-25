using BANCOEMPLEOJAC.Repositorio.DBContext;
using Microsoft.EntityFrameworkCore;

using BANCOEMPLEOJAC.Repositorio;
using BANCOEMPLEOJAC.Repositorio.Interfase;
using BANCOEMPLEOJAC.Repositorio.Implementacion;
using BANCOEMPLEOJAC.Utilidades;
using BANCOEMPLEOJAC.Servicio.Implementacion;
using BANCOEMPLEOJAC.Servicio.Interfase;
using BANCOEMPLEOJAC.Servicio.Contrato;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Bancoempleojac99Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"));
});

builder.Services.AddTransient(typeof(IGenericoRepositorio<>), typeof(GenericoRepositorio<>));
builder.Services.AddScoped<IContratoRepositorio, ContratoRepositorio>();

builder.Services.AddAutoMapper(typeof(AutoMaperProfile));

builder.Services.AddScoped<IActividadEconomicaServicio, ActividadEconomicaServicio>();
builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddScoped<IPerfilCargoServicio, PerfilCargoServicio>();
builder.Services.AddScoped<ICategoriaServicio, CategoriaServicio>();
builder.Services.AddScoped<IEmpleoServicio, EmpleoServicio>();
builder.Services.AddScoped<IServicioServicio, ServicioServicio>();
builder.Services.AddScoped<IPropuestaEmpleoServicio, PropuestaEmpleoServicio>();
builder.Services.AddScoped<IPropuestaServicioServicio, PropuestaServicioServicio>();
builder.Services.AddScoped<IContratoServicio, ContratoServicio>();
builder.Services.AddScoped<IDashboardServicio, DashboardServicio>();
builder.Services.AddScoped<IJacServicio, JacServicio>();
builder.Services.AddScoped<IRolServicio, RolServicio>();
//builder.Services.AddScoped<IEnvioCorreoServicio, EnvioCorreoServicio>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Politica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Politica");

app.UseAuthorization();

app.MapControllers();

app.Run();
