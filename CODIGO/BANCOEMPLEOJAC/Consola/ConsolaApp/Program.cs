
namespace BancoEmpleo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("¡Bienvenido a BANCOEMPLEO!");
            Console.WriteLine("Por favor ingrese su nombre:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Hola " + nombre + "! ¿Eres un Empleador o un Empleado?");
            string tipoUsuario = Console.ReadLine();
            if (tipoUsuario.ToLower() == "empleador")
            {
                Console.WriteLine("¡Bienvenido Empleador!");
                // Lógica para Empleadores
                Console.WriteLine("Por favor ingrese los detalles del empleo que desea ofrecer:");
                string detallesEmpleo = Console.ReadLine();
                Console.WriteLine("Gracias por ingresar los detalles del empleo. ¿Desea publicar este empleo en BANCOEMPLEO? (Sí/No)");
                string publicarEmpleo = Console.ReadLine();
                if (publicarEmpleo.ToLower() == "sí")
                {
                    // Lógica para publicar el empleo
                    Console.WriteLine("El empleo ha sido publicado con éxito.");
                }
                else
                {
                    Console.WriteLine("El empleo no ha sido publicado.");
                }
            }
            else if (tipoUsuario.ToLower() == "empleado")
            {
                Console.WriteLine("¡Bienvenido Empleado!");
                // Lógica para Empleados
                Console.WriteLine("Por favor ingrese los detalles del empleo que está buscando:");
                string detallesEmpleo = Console.ReadLine();
                Console.WriteLine("Gracias por ingresar los detalles del empleo. ¿Desea buscar este empleo en BANCOEMPLEO? (Sí/No)");
                string buscarEmpleo = Console.ReadLine();
                if (buscarEmpleo.ToLower() == "sí")
                {
                    // Lógica para buscar el empleo
                    Console.WriteLine("Se han encontrado 3 empleos que coinciden con su búsqueda:");
                    Console.WriteLine("- Empleo 1");
                    Console.WriteLine("- Empleo 2");
                    Console.WriteLine("- Empleo 3");
                }
                else
                {
                    Console.WriteLine("La búsqueda de empleos ha sido cancelada.");
                }
            }
            else
            {
                Console.WriteLine("Tipo de usuario no válido.");
            }
        }
    }
}

