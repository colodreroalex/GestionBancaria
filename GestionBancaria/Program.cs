using BGCuentas;

namespace GestionBancaria
{
    
    //ENUMERACIONES
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

            Controlador.ControladorPrincipal();


        }

    }
}