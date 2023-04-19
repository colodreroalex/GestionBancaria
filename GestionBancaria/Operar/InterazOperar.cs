using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBancaria
{
    public static partial class Interfaz
    {
        public static void MenuOperaciones()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("\t0.-Salir");
            Console.WriteLine("\t1.-Ingresar");
            Console.WriteLine("\t2.-Retirar");
        }

        internal static double LeerCantidad(OperacionesCuenta operacion)
        {
            double dinero = 0;

            bool cantidadOk;
            do
            {
                cantidadOk = false;

                Console.Write($"Introduca la cantidad a {operacion}: ");

                try
                {
                    dinero = Convert.ToDouble(Console.ReadLine());
                    cantidadOk = true;
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }


            } while (!cantidadOk);




            return dinero;
        }

        public static OperacionesCuenta OpcionMenuOperaciones()
        {
            OperacionesCuenta operaciones = OperacionesCuenta.Salir;
            bool opcionCorrecta;

            do
            {
                opcionCorrecta = false;

                //MOSTRAR MENU OPERACIONES
                MenuOperaciones();

                //SELECCIONAR TIPO DE CUENTAS
                try
                {
                    operaciones = (OperacionesCuenta)LeerOpcion((byte)OperacionesCuenta.Salir, (byte)OperacionesCuenta.Retirar);
                    opcionCorrecta = true;
                }
                catch (Exception err5)
                {
                    InformarError(err5.Message);
                }

            } while (!opcionCorrecta);


            return operaciones;
        }


    }
}
