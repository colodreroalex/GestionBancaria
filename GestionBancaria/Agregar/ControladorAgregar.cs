using BGCuentas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBancaria
{
    public static partial class Controlador
    {
        static void AgregarCuenta(List<Cuenta> lista)
        {

            bool salir = false;
            int indice = -1;
            AgregarCuenta cuenta = GestionBancaria.AgregarCuenta.Salir;

            string nombre = "";
            double cantidad = 0;
            int edad = 0;
            do
            {

                //CAPTAR OPCION MENU SECUNDARIO
                cuenta = Interfaz.OpcionMenuAgregar();



                //EJECUTAR LA OPCION - AGREGAR LA CUENTA
                switch (cuenta)
                {
                    case GestionBancaria.AgregarCuenta.Salir:
                        salir = true;
                        break;
                    case GestionBancaria.AgregarCuenta.Cuenta_Joven:

                        Añadir(lista);//?????


                        break;



                    case GestionBancaria.AgregarCuenta.Cuenta_Oro:
                        Añadir(lista);

                        break;



                    case GestionBancaria.AgregarCuenta.Cuenta_Platino:
                        break;
                }

            } while (!salir);




        }


        private static void Añadir(List<Cuenta> lista)
        {
            string nombre = "";
            int edad = 0;
            double cantidad = 0;
            bool esOk;

            do
            {
                esOk = false;

                try
                {

                    DatosCuenta(nombre, cantidad, edad);
                    esOk = true;


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }


            } while (!esOk);


        }


        private static void DatosCuenta(string? nombre, double cantidad, int edad)
        {
            Console.WriteLine($"Ingrese nombre para su cuenta: ");
            nombre = Console.ReadLine();
            Console.WriteLine("Ahora introduce la edad: ");
            edad = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Introduce la cantidad para esta cuenta(No puede estar vacia): ");
            cantidad = Double.Parse(Console.ReadLine());

        }





    }
}
