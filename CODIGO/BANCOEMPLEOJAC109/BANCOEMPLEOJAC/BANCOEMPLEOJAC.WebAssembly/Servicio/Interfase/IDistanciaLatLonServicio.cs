using BANCOEMPLEOJAC.DTO;

namespace BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase
{
    public interface IDistanciaLatLonServicio
    {
        Task<double> CalcularDistancia(DistanciaDTO modelo);
    }
}
