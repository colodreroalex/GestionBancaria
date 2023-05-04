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
        //public static void MostrarDatosCuenta(Cuenta cuenta)
        //{
        //    //MOSTRAR TIPO DE CUENTA
        //    string tipoCuenta = "";
        //    int edad = 0;

        //    if (cuenta is CuentaJoven)
        //    {
        //        tipoCuenta = "Cuenta Joven";
        //        //MOSTRAR EDAD  - Casting (Parentesis importante)
        //        edad = ((CuentaJoven)cuenta).Edad;
        //    }

        //    if (cuenta is CuentaOro)
        //    {
        //        tipoCuenta = "Cuenta Oro";
        //        edad = ((CuentaOro)cuenta).Edad;
        //    }

        //    if (cuenta is CuentaPlatino)
        //    {
        //        tipoCuenta = "Cuenta Platino";
        //        edad = ((CuentaPlatino)cuenta).Edad;
        //    }

        //    Console.Clear();
        //    Console.WriteLine($"*** GESTION DE CUENTAS ***");
        //    Console.WriteLine($"---------- DATOS DE LA CUENTA -----------\n");
        //    Console.WriteLine($"Tipo de la cuenta: {tipoCuenta}");
        //    Console.WriteLine($"Titular: {cuenta.Titular}");
        //    Console.WriteLine($"Edad: {edad}");
        //    Console.WriteLine($"Saldo: {cuenta.Saldo}");

        //    Console.WriteLine($"Pulse ENTER para continuar...");
        //    Console.ReadLine();


        //}

        internal static void MostrarListaCuentas(List<Cuenta> listaCuentas)
        {
            int indice = 1; //Indice para la lista de cuentas (No usar "var")

            Console.Clear();
            Console.WriteLine("***GESTION DE CUENTAS BANCARIAS***");
            Console.WriteLine("----------- LISTADO DE CUENTAS -------");
            Console.WriteLine("\t0.-Salir");

            foreach (Cuenta cuenta in listaCuentas)
            {
                Console.WriteLine($"\t{indice}.- {cuenta.Titular}");
                Console.WriteLine("");
                indice++;

            }

        }

        //    //LEER OPCION()
        //}

        public static int ElementoListaCuentas(List<Cuenta> lista)
        {
            int opcion = 0;
            bool opcionCorrecta;

            do
            {
                opcionCorrecta = false;
                MostrarListaCuentas(lista);

                try
                {
                    //Seleccionar la cuenta a ...
                    opcion = LeerOpcion((byte)Opcion.Salir, (byte)lista.Count);
                    opcionCorrecta = true;

                }
                catch (Exception ex1)
                {
                    InformarError(ex1.Message);
                }

            } while (!opcionCorrecta);


            return opcion - 1;
            //-1 Porque si le pasas la cuenta n.15 , en memoria es la 14 en realidad.
            //Si no hacemos esto modificamos cuentas que no son

        }


        public static void MenuConsultarCuenta()
        {
            Console.Clear();
            Console.WriteLine("");
            //Console.WriteLine("\t1.-Cuenta General");
            Console.WriteLine("\t0.-Salir");
            Console.WriteLine("\t1.-Cuenta Joven");
            Console.WriteLine("\t2.-Cuenta Oro");
            Console.WriteLine("\t3.-Cuenta Platino\n");
        }


        public static OTipoCuenta OpcionMenuConsultar()
        {

            //RECURSOS 
            OTipoCuenta cuenta = OTipoCuenta.Salir;
            bool opcionCorrecta;

            do
            {
                opcionCorrecta = false;
                //Mostrar Menu de tipo de Cuentas
                MenuConsultarCuenta();
                //SELECCIONAR EL TIPO DE CUENTA
                try
                {
                    cuenta = (OTipoCuenta)LeerOpcion((byte)OTipoCuenta.Salir, (byte)OTipoCuenta.Cuenta_Platino);
                    opcionCorrecta = true;
                }
                catch (Exception err)
                {
                    InformarError(err.Message);
                }

            } while (!opcionCorrecta);

            return cuenta;
        }


    }
}
