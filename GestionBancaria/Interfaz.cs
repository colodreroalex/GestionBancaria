using BGCuentas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GestionBancaria
{
    internal class Interfaz
    {
        /// <summary>
        /// Menu principal de la Aplicacion
        /// </summary>
        public static void MenuPrincipal()
        {
            //Aqui no valido ninguna opcion ya que el menu lo mostrare en mas sitios , por eso
            //creare un metodo solo de validacion
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine($"\t0.- Salir");
            Console.WriteLine($"\t1.- Agregar Cuenta");
            Console.WriteLine($"\t2.- Modificar Cuenta");
            Console.WriteLine($"\t3.- Eliminar Cuenta");
            Console.WriteLine($"\t4.- Consultar");
            Console.WriteLine($"\t5.- Operar");
            Console.WriteLine($"\t6.- Cargar Datos\n");

        }

        public static void MenuAgregarCuenta()
        {
            Console.Clear();
            Console.WriteLine("");
            //Console.WriteLine("\t1.-Cuenta General");
            Console.WriteLine("\t0.-Salir");
            Console.WriteLine("\t1.-Cuenta Joven");
            Console.WriteLine("\t2.-Cuenta Oro");
            Console.WriteLine("\t3.-Cuenta Platino\n");
        }

        public static void MenuOperaciones()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("\t0.-Salir");
            Console.WriteLine("\t1.-Ingresar");
            Console.WriteLine("\t2.-Retirar");
        }

        public static byte LeerOpcion(byte opMin, byte opMax)
        {
            byte op;

            Console.Write("\tIntroduzca su elección: ");
            op = Convert.ToByte(Console.ReadLine());

            if (op < opMin) throw new Exception($"Opcion {op} no válida");
            if (op > opMax) throw new Exception($"Opcion {op} no válida");

            return op;
        }

        public static void InformarError(string message)
        {
            Console.WriteLine("\nSE HA PRODUCIDO UN ERROR");
            Console.WriteLine($"ERROR: {message}");
            Console.WriteLine("Pulse ENTER para continuar...");
            Console.ReadLine(); //Vaciar buffer del teclado 
        }



        public static Opcion OpcionDelMenuPrincipal()
        {
            //RECURSOS
            Opcion opcion = Opcion.Cargar;  //Inicializacion por ejemplo
            bool opcionCorrecta;


            do
            {
                opcionCorrecta = false;

                //Mostrar el MENU PRINCIPAL
                Interfaz.MenuPrincipal();

                //SELECCIONAR OPCION
                try
                {
                    opcion = (Opcion)Interfaz.LeerOpcion((byte)Opcion.Salir, (byte)Opcion.Cargar);
                    opcionCorrecta = true;

                }
                catch (Exception ex) //Se podrian generar excepciones personalizadas
                {
                    Interfaz.InformarError(ex.Message);

                }

            } while (!opcionCorrecta);



            return opcion;
        }

        public static AgregarCuenta OpcionMenuAgregar()
        {

            //RECURSOS 
            AgregarCuenta cuenta = AgregarCuenta.Salir;
            bool opcionCorrecta;

            do
            {
                opcionCorrecta = false;
                //Mostrar Menu de tipo de Cuentas
                MenuAgregarCuenta();
                //SELECCIONAR EL TIPO DE CUENTA
                try
                {
                    cuenta = (AgregarCuenta)LeerOpcion((byte)AgregarCuenta.Salir, (byte)AgregarCuenta.Cuenta_Platino);
                    opcionCorrecta = true;
                }
                catch (Exception err)
                {
                    InformarError(err.Message);
                }

            } while (!opcionCorrecta);

            return cuenta;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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

        internal static void MostrarListaCuentas(List<Cuenta> listaCuentas)
        {
            int indice = 1; //Indice para la lista de cuentas (No usar "var")
            
            Console.Clear();
            Console.WriteLine("***GESTION DE CUENTAS BANCARIAS***");
            Console.WriteLine("----------- LISTADO DE CUENTAS -------");
            Console.WriteLine("\t0.-Salir");

            foreach(Cuenta cuenta in listaCuentas)
            {
                Console.WriteLine($"\t{indice}.- {cuenta.Titular}");
                Console.WriteLine("");
                indice++;
                
            }

            

            //LEER OPCION()
        }

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
                    opcion = LeerOpcion((byte)Opcion.Salir, (byte)lista.Count);
                    opcionCorrecta = true;
                }
                catch(Exception ex1)
                {
                    InformarError (ex1.Message);
                }

            } while (!opcionCorrecta); 


            return opcion - 1;  
            //-1 Porque si le pasas la cuenta n.15 , en memoria es la 14 en realidad.
            //Si no hacemos esto modificamos cuentas que no son

        }

        public static void EstablecerTitularCuenta(Cuenta cuenta)//porque llamas aqui a cuenta si es un objeto
        {
            string nombre;

            //Solicitar Titular
            Console.Write("\n\tIntroduzca nuevo titular: ");
            nombre = Console.ReadLine();

            //Establecer Titular
            cuenta.Titular = nombre; 
        }


    }
}
