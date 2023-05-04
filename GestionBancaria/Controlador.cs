using BGCuentas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace GestionBancaria
{
    public static partial class Controlador //Publica y estatica porque solo contendra elementos estaticos
                                                //PARTIAL--> Preparamos la clase para extenderla a otrs ficheros secundarios 
    {
        public static void ControladorPrincipal()
        {
            bool salir = false;
            Opcion opcion = Opcion.Cargar;  //opcion.cargar , como si inicializar un INT a 0 por ejemplo, da igual


            //COLECCION DE CREAR DATOS
            //Como trabajo con memoria y tengo que pasar los datos de un lado para otro creo una coleccion

                //AL TRABAJAR CON FICHEROS ESTO DESAPARECE
            List<Cuenta> listaCuentas = new List<Cuenta>();

            //Coleccion de la clase Cuenta(BASE), es decir, dentro de esta coleccion puedes tocar las otras tb

            do
            {
                //CAPTAR OPCION DEL MENU PRINCIPAL
                opcion = Interfaz.OpcionDelMenuPrincipal();


                //EJECUTAR ACCION SEGUN LA OPCION
                switch (opcion)
                {
                    case Opcion.Salir:
                        //Preguntar confirmacion para salir
                        salir = true;
                        break;

                    case Opcion.Agregar:
                        AgregarCuenta();                    //SUBMODULOS
                        break;

                    case Opcion.Modificar:
                        //LISTA DE las cuentas a modificar
                        ModificarCuenta(listaCuentas);                    //SUBMODULOS
                        break;

                    case Opcion.Eliminar:
                        EliminarCuenta(listaCuentas);                    //SUBMODULOS
                        break;

                    case Opcion.Consultar:
                        /*ConsultarCuenta(listaCuentas);*/                    //SUBMODULOS
                        ConsultarFcihero();

                        break;

                    case Opcion.Operar:
                        OperarCuenta(listaCuentas);                    //SUBMODULOS
                        break;

                    case Opcion.Cargar:
                        CargarCuentas(listaCuentas);
                        break;
                }

            } while (!salir);   //Se repite hasta que el user quiera salir
        }

        private static void CargarCuentas(List<Cuenta> listaCuentas)
        {
            //Cuenta Joven
            //listaCuentas.Add(new CuentaJoven("Federico", 100, 20));
            //listaCuentas.Add(new CuentaJoven("Federico1", 200, 25));
            //listaCuentas.Add(new CuentaJoven("Federico2", 300, 18));
            //listaCuentas.Add(new CuentaJoven("Federico3", 400, 26));
            //listaCuentas.Add(new CuentaJoven("Federico4", 500, 23));

            //CREACION DE CUENTAS EN EL FICHERO
            Gfichero.AgregarCuenta(new CuentaJoven("Federico", 100, 20));
            Gfichero.AgregarCuenta(new CuentaJoven("Federico1", 200, 25));
            Gfichero.AgregarCuenta(new CuentaJoven("Federico2", 300, 18));
            Gfichero.AgregarCuenta(new CuentaJoven("Federico3", 400, 26));
            Gfichero.AgregarCuenta(new CuentaJoven("Federico4", 500, 23));

            Gfichero.AgregarCuenta(new CuentaPlatino("Roberto", 100000, 30));
            Gfichero.AgregarCuenta(new CuentaPlatino("Roberto1", 100000, 30));
            Gfichero.AgregarCuenta(new CuentaPlatino("Roberto2", 100000, 30));
            Gfichero.AgregarCuenta(new CuentaPlatino("Roberto3", 100000, 30));
            Gfichero.AgregarCuenta(new CuentaPlatino("Roberto4", 100000, 30));



            ////Cuenta Oro
            //listaCuentas.Add(new CuentaOro("Alfredo", 150, 27));
            //listaCuentas.Add(new CuentaOro("Alfredo1", 123, 28));
            //listaCuentas.Add(new CuentaOro("Alfredo2", 432, 36));
            //listaCuentas.Add(new CuentaOro("Alfredo3", 132, 29));
            //listaCuentas.Add(new CuentaOro("Alfredo4", 111, 44));


            ////Cuenta Platino
            //listaCuentas.Add(new CuentaPlatino("Roberto", 100000, 30));
            //listaCuentas.Add(new CuentaPlatino("Roberto1", 100000, 30));
            //listaCuentas.Add(new CuentaPlatino("Roberto2", 100000, 30));
            //listaCuentas.Add(new CuentaPlatino("Roberto3", 100000, 30));
            //listaCuentas.Add(new CuentaPlatino("Roberto4", 100000, 30));



            Console.WriteLine("\n\tDatos Correctamente cargados! Pulsa ENTER para continuar...");
            Console.ReadLine(); 

        }

    }
}
