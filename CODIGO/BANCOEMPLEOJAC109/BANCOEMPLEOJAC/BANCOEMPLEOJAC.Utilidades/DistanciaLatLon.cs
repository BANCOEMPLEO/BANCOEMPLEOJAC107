using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.Utilidades
{
    public class DistanciaLatLon
    {
        public static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }

        public static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            // Convierte las coordenadas de grados a radianes
            double radLat1 = DegreesToRadians(lat1);
            double radLon1 = DegreesToRadians(lon1);
            double radLat2 = DegreesToRadians(lat2);
            double radLon2 = DegreesToRadians(lon2);

            // Calcula las diferencias de latitud y longitud
            double dlat = radLat2 - radLat1;
            double dlon = radLon2 - radLon1;

            // Fórmula de Haversine
            double a = Math.Pow(Math.Sin(dlat / 2.0), 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(dlon / 2.0), 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            // Radio de la Tierra en kilómetros (aproximado)
            double radius = 6371.0;

            // Calcula la distancia
            double distance = radius * c;

            return distance;
        }
        //// Ejemplo de uso
        //double latitudPunto1 = 34.0522;
        //double longitudPunto1 = -118.2437;
        //double latitudPunto2 = 40.7128;
        //double longitudPunto2 = -74.0060;

        //double distanciaKm = CalculateDistance(latitudPunto1, longitudPunto1, latitudPunto2, longitudPunto2);
        //Console.WriteLine($"La distancia entre los dos puntos es aproximadamente {distanciaKm:F2} kilómetros.");
    }
}
