using BGCuentas;

namespace GestionBancaria
{
    //AGREGAR CUENTA PARA EL MIERCOLES

   


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
                        EliminarCuenta(listaCuentas);
                        break;

                    case Opcion.Consultar:
                        ConsultarCuenta(listaCuentas);
                        break;

                    case Opcion.Operar:
                        OperarCuenta(listaCuentas);
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
                //IMPORTANTE
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

        static void EliminarCuenta(List<Cuenta> lista)
        {
            int indice = -1;
            bool salir = false;

            
            do
            {
                //Mostrar Lista de Cuentas Existentes - POLIMORFISMO
                indice = Interfaz.ElementoListaCuentas(lista);

                if (Interfaz.ConfirmarOperacion("Eliminar", lista[indice]))

                    //Ejecutar la opcion - Eliminar la cuenta
                    lista.Remove(lista[indice]);

                //IMPORTANTE
                else salir = true; 

            } while (!salir);
            

            
        }

        static void ConsultarCuenta(List<Cuenta> lista)
        {
            int indice = -1;
            bool salir = false;
            //Mostrar Lista de Cuentas Existentes - POLIMORFISMO
            do
            {

                indice = Interfaz.ElementoListaCuentas(lista);

                if (indice >= 0)
                {
                    Interfaz.MostrarCuenta(lista[indice]);

                }
                //IMPORTANTE
                else salir = true; 

            } while (!salir);
            //Seleccionar la cuenta a Consultar

            //Ejecutar la opcion - Consultar la cuenta
        }

        static void OperarCuenta(List<Cuenta> lista)
        {
            bool salir = false;
            int indice = -1;
            OperacionesCuenta operaciones = OperacionesCuenta.Salir;

            do
            {

                //Seleccionar la cuenta con la que operar
                indice = Interfaz.ElementoListaCuentas(lista);

                if (indice >= 0)
                {
                    //Captar la operacion  a realizar
                    operaciones = Interfaz.OpcionMenuOperaciones();

                    //EJECUTAR LA OPCION - OPERAR EN LA CUENTA
                    switch (operaciones)
                    {
                        case OperacionesCuenta.Salir:
                            salir = true;
                            break;
                        case OperacionesCuenta.Ingresar:
                            IngresarCuenta(lista[indice]);
                            break;
                        case OperacionesCuenta.Retirar:
                            RetirarCuenta(lista[indice]);
                            break;
                    }
                }
                //IMPORTANTE
                else salir = true; 
               

            } while (!salir);
        }

        private static void RetirarCuenta(Cuenta cuenta)
        {
            double cantidad;

            cantidad = Interfaz.LeerCantidad(OperacionesCuenta.Retirar);

            try
            {
                cuenta.Retirar(cantidad);
            }
            catch (Exception ex)
            {
                Interfaz.InformarError(ex.Message);
            }



        }

        private static void IngresarCuenta(Cuenta cuenta)
        {
            double cantidad;


            //Establecemos la cantidad a operar
            cantidad = Interfaz.LeerCantidad(OperacionesCuenta.Ingresar);

            try 
            {
                cuenta.Ingresar(cantidad);
            }
            catch(BGCuentas.CantidadException err)
            {
                Interfaz.InformarError(err.Message);
            }

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