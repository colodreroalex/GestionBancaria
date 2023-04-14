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

            List<Cuenta> listaCuentas = new List<Cuenta>(); //Coleccion de la clase Cuenta(BASE), es decir, dentro de esta coleccion puedes tocar las otras tb

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
                        ModificarCuenta();
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
                        CargarCuenta();
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
            Cuenta cuenta1 = new Cuenta("Pepeeeee");

            do
            {

                //CAPTAR OPCION MENU SECUNDARIO
                cuenta = Interfaz.OpcionMenuSecundario();
                


                //EJECUTAR LA OPCION - AGREGAR LA CUENTA
                switch (cuenta)
                {
                    case GestionBancaria.AgregarCuenta.Salir:
                        salir = true; 
                        break;
                    case GestionBancaria.AgregarCuenta.Cuenta_Joven:
                        lista.Add(cuenta1);
                        break;
                    case GestionBancaria.AgregarCuenta.Cuenta_Oro:
                        break;
                    case GestionBancaria.AgregarCuenta.Cuenta_Platino:
                        break; 
                }

            } while (!salir);
            



        }

        static void ModificarCuenta()
        {
            //Mostrar Lista de Cuentas Existentes - POLIMORFISMO

            //Seleccionar la cuenta a modificar

            //Ejecutar la opcion - Modificar la cuenta
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

        static void CargarCuenta()
        {
            //Mostrar Lista de Cuentas Existentes - POLIMORFISMO

            //Seleccionar la cuenta a Cargar

            //Ejecutar la opcion - Cargar la cuenta
        }

    }
}