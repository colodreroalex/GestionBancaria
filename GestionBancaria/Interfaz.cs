using BGCuentas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GestionBancaria
{
    public static partial class Interfaz
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
