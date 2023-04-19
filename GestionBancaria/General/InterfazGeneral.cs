using BGCuentas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBancaria
{
    public static partial class Interfaz
    {
        public static byte LeerOpcion(byte opMin, byte opMax)
        {
            byte opcion;

            Console.Write("\tIntroduzca su elección: ");
            opcion = Convert.ToByte(Console.ReadLine());

            if (opcion < opMin) throw new Exception($"Opcion {opcion} no válida");
            if (opcion > opMax) throw new Exception($"Opcion {opcion} no válida");

            return opcion;
        }

        public static void InformarError(string message)
        {
            Console.WriteLine("\nSE HA PRODUCIDO UN ERROR");
            Console.WriteLine($"ERROR: {message}");
            Console.WriteLine("Pulse ENTER para continuar...");
            Console.ReadLine(); //Vaciar buffer del teclado 
        }

        public static bool ConfirmarOperacion(string mensaje, Cuenta cuenta)
        {
            bool respuesta = false; //Control de respuesta --> Pa empezar decimos que sera NO(false)
            byte opcion = 0;        //Inicializacion por defecto
            bool opcionCorrecta;    //Control para el bucle --> Se repite cuando sea false, sale si es true

            do
            {

                //False para que se repita el bucle
                opcionCorrecta = false;

                //Mensajito Interfaz para el user
                Console.WriteLine($"\n\tConfirme la accion: ¿Desea {mensaje} la cuenta?");
                Console.WriteLine($"\tTitular: {cuenta.Titular}  Saldo: {cuenta.Saldo}");
                Console.WriteLine("\t0.-\tNo");
                Console.WriteLine("\t1.-\tSi");

                try
                {
                    //Agregamos la opcion a opcion
                    opcion = LeerOpcion(0, 1);

                    //Salimos del bucle
                    opcionCorrecta = true;
                }
                catch (Exception err)
                {
                    //Mensajito de error
                    InformarError(err.Message);
                }

            } while (!opcionCorrecta);

            //Si la opcion del usuario es 1, entonces respuesta verdadera
            if (opcion == 1) respuesta = true;

            //Devolvemos la respuesta
            return respuesta;

        }
    }
}
