using BGCuentas;

namespace GestionBancaria
{

    public enum Opcion : byte { Salir, Agregar, Modificar, Eliminar, Consultar, Operar, Cargar }

    public enum AgregarCuenta : byte { Salir, Cuenta_Joven, Cuenta_Oro, Cuenta_Platino }

    public enum OperacionesCuenta : byte { Salir, Ingresar, Retirar }

    internal class Program
    {
        /// <summary>
        /// Controlador principal de la aplicacion
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            bool salir = false;
            Opcion opcion = Opcion.Cargar;  //opcion.cargar , como si inicializar un INT a 0 por ejemplo, da igual


            //COLECCION DE CREAR DATOS
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
                        AgregarCuenta(listaCuentas);
                        break;

                    case Opcion.Modificar:
                        //LISTA DE las cuentas a modificar
                        ModificarCuenta(listaCuentas);
                        break;

                    case Opcion.Eliminar:
                        EliminarCuenta();
                        break;

                    case Opcion.Consultar:
                        ConsultarCuenta();
                        break;

                    case Opcion.Operar:
                        OperarCuenta();
                        break;

                    case Opcion.Cargar:
                        CargarCuentas(listaCuentas);
                        break;
                }

            } while (!salir);



        }









        /// <summary>
        /// Controlador secundario: Adicion de cuentas
        /// </summary>
        static void AgregarCuenta(List<Cuenta> lista)
        {

            bool salir = false;
            AgregarCuenta cuenta = GestionBancaria.AgregarCuenta.Salir;


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

                        break;
                    case GestionBancaria.AgregarCuenta.Cuenta_Oro:
                        break;
                    case GestionBancaria.AgregarCuenta.Cuenta_Platino:
                        break;
                }

            } while (!salir);




        }

        static void ModificarCuenta(List<Cuenta> lista)
        {
            int indiceCuenta = -1;
            bool salir = false; //Suponemos que va a fallar 

            do
            {
                
                indiceCuenta = Interfaz.ElementoListaCuentas(lista);

                if (indiceCuenta >= 0)
                {
                    Interfaz.EstablecerTitularCuenta(lista[indiceCuenta]);  //porque????       

                }
                else salir = true; 
                

            } while (!salir);

            //Mostrar Lista de Cuentas Existentes - POLIMORFISMO
            
            //Seleccionar la cuenta a modificar

            //Ejecutar la opcion - Modificar la cuenta

            
        }

        private static void CambiarTitularCuenta()
        {
            throw new NotImplementedException();
        }

        static void EliminarCuenta()
        {
            //Mostrar Lista de Cuentas Existentes - POLIMORFISMO

            //Seleccionar la cuenta a eliminar

            //Ejecutar la opcion - Eliminar la cuenta
        }

        static void ConsultarCuenta()
        {
            //Mostrar Lista de Cuentas Existentes - POLIMORFISMO

            //Seleccionar la cuenta a Consultar

            //Ejecutar la opcion - Consultar la cuenta
        }

        static void OperarCuenta()
        {
            bool salir = false;
            OperacionesCuenta operaciones = new OperacionesCuenta();

            do
            {

                operaciones = Interfaz.OpcionMenuOperaciones();

                //EJECUTAR LA OPCION - OPERAR EN LA CUENTA
                switch (operaciones)
                {
                    case OperacionesCuenta.Salir:
                        salir = true;
                        break;
                    case OperacionesCuenta.Ingresar:
                        break;
                    case OperacionesCuenta.Retirar:
                        break;
                }


            } while (!salir);
        }



        /// <summary>
        /// Carga de datos de prueba en las cuentas
        /// </summary>
        /// <param name="listaCuentas">Coleccion de cuentas a la que añadir los datos de prueba</param>
        private static void CargarCuentas(List<Cuenta> listaCuentas)
        {
            //Cuenta Joven
            listaCuentas.Add(new CuentaJoven("Federico", 100, 20));
            listaCuentas.Add(new CuentaJoven("Federico1", 200, 25));
            listaCuentas.Add(new CuentaJoven("Federico2", 300, 18));
            listaCuentas.Add(new CuentaJoven("Federico3", 400, 26));
            listaCuentas.Add(new CuentaJoven("Federico4", 500, 23));


            //Cuenta Oro
            listaCuentas.Add(new CuentaOro("Alfredo", 150, 27));
            listaCuentas.Add(new CuentaOro("Alfredo1", 123, 28));
            listaCuentas.Add(new CuentaOro("Alfredo2", 432, 36));
            listaCuentas.Add(new CuentaOro("Alfredo3", 132, 29));
            listaCuentas.Add(new CuentaOro("Alfredo4", 111, 44));


            //Cuenta Platino
            listaCuentas.Add(new CuentaPlatino("Roberto", 100000, 30));
            listaCuentas.Add(new CuentaPlatino("Roberto1", 100000, 30));
            listaCuentas.Add(new CuentaPlatino("Roberto2", 100000, 30));
            listaCuentas.Add(new CuentaPlatino("Roberto3", 100000, 30));
            listaCuentas.Add(new CuentaPlatino("Roberto4", 100000, 30));

            Console.WriteLine("\n\tDatos Correctamente cargados! Pulsa ENTER para continuar...");
            
        }




    }
}