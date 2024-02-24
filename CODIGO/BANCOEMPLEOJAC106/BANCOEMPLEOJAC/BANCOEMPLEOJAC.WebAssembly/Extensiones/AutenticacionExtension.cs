using Blazored.LocalStorage;
using BANCOEMPLEOJAC.DTO;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;



namespace BANCOEMPLEOJAC.WebAssembly.Extensiones
{
    public class AutenticacionExtension : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private ClaimsPrincipal _sinInformacion = new ClaimsPrincipal(new ClaimsIdentity());

        public AutenticacionExtension(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task ActualizarestadoAutenticacion(SesionDTO sesionUsuario)
        {
            ClaimsPrincipal claimsPrincipal;

            if (sesionUsuario != null)
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, sesionUsuario.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Name, sesionUsuario.Nombres),
                    new Claim(ClaimTypes.Surname, sesionUsuario.Apellidos),
                    new Claim(ClaimTypes.Email, sesionUsuario.Correo),
                    new Claim(ClaimTypes.Locality, sesionUsuario.JacId.ToString()),
                    new Claim(ClaimTypes.Role, sesionUsuario.Rol.ToString()),
                    new Claim(ClaimTypes.MobilePhone, sesionUsuario.Celular)

                }, "JwtAuth"));

                await _localStorage.SetItemAsync("sesionUsuario", sesionUsuario);

            }
            else
            {
                claimsPrincipal = _sinInformacion;
                await _localStorage.RemoveItemAsync("sesionUsuario");
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));

        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var sesionUsuario = await _localStorage.GetItemAsync<SesionDTO>("sesionUsuario");

            if (sesionUsuario == null)
                return await Task.FromResult(new AuthenticationState(_sinInformacion));

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, sesionUsuario.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Name, sesionUsuario.Nombres),
                    new Claim(ClaimTypes.Surname, sesionUsuario.Apellidos),
                    new Claim(ClaimTypes.Email, sesionUsuario.Correo),
                    new Claim(ClaimTypes.Locality, sesionUsuario.JacId.ToString()),
                    new Claim(ClaimTypes.Role, sesionUsuario.Rol.ToString()),
                    new Claim(ClaimTypes.MobilePhone, sesionUsuario.Celular),

                }, "JwtAuth"));
            return await Task.FromResult(new AuthenticationState(claimsPrincipal));

        }
    }
}
