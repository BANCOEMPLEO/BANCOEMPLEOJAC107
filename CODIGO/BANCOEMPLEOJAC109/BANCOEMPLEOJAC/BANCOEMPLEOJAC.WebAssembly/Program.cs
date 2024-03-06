using BANCOEMPLEOJAC.WebAssembly;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using Blazored.LocalStorage;
using Blazored.Toast;
using BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase;
using BANCOEMPLEOJAC.WebAssembly.Servicio.Implementacion;

using CurrieTechnologies.Razor.SweetAlert2;

using Microsoft.AspNetCore.Components.Authorization;
using BANCOEMPLEOJAC.WebAssembly.Extension;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5191/api/") });

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();

builder.Services.AddScoped<IActividadEconomicaServicio, ActividadEconomicaServicio>();
builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddScoped<ICategoriaServicio, CategoriaServicio>();
builder.Services.AddScoped<IPerfilCargoServicio, PerfilCargoServicio>();
builder.Services.AddScoped<IEmpleoServicio, EmpleoServicio>();
builder.Services.AddScoped<IServicioServicio, ServicioServicio>();
builder.Services.AddScoped<IPropuestaEmpleoServicio, PropuestaEmpleoServicio>();
builder.Services.AddScoped<IPropuestaServicioServicio, PropuestaServicioServicio>();
builder.Services.AddScoped<IContratoServicio, ContratoServicio>();
builder.Services.AddScoped<IDashboardServicio, DashboardServicio>();
builder.Services.AddScoped<ICarritoServicio, CarritoServicio>();
builder.Services.AddScoped<IJacServicio, JacServicio>();
builder.Services.AddScoped<IRolServicio, RolServicio>();

//builder.Services.AddScoped<IWhastAppServicio, WhastAppServicio>();

builder.Services.AddSweetAlert2();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AutenticacionExtension>();

await builder.Build().RunAsync();
