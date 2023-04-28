using BGCuentas;

namespace GestionBancaria
{
    
    //ENUMERACIONES
    public enum Opcion : byte { Salir, Agregar, Modificar, Eliminar, Consultar, Operar, Cargar }

    public enum OTipoCuenta : byte { Salir, Cuenta_Joven, Cuenta_Oro, Cuenta_Platino }

    public enum OperacionesCuenta : byte { Salir, Ingresar, Retirar }


    /* 
DISEÑO FORMATO FICHEROS TEXTO                                               /    Nombre del fichero: productos.sgb
    Informacion/Datos a ALMACENAR                                           /   
                                                                            /   1.-Existe el fichero? si(continuar),no(crearlo)
0                                                   --> 4 lineas de texto   /   2.-Continuar
                                                                            /       -Abrir Fichero para añadir
    -TipoCuenta(joven, oro, platino)    \n                                  /       -Agregar la cuenta
    -Titular                            \n                                  /
    -Edad                               \n                                  /
    -Saldo                              \n                                  /
                                                                            /
                                                                            /
1                                                                           /
    -TipoCuenta(joven, oro, platino)    \n                                  /
    -Titular                            \n                                  /
    -Edad                               \n                                  /
    -Saldo                              \n                                  /
                                                                            /
                                                                            /
                                                                            /
n                                                                           /
    -TipoCuenta(joven, oro, platino)    \n                                  /
    -Titular                            \n                                  /
    -Edad                               \n                                  /
    -Saldo                              \n                                  /
                                                                            /
                                                                            /
                                                                            /
                                                                            /
                                                                            /
                                                                            /
                                                                            /
                                                                            /
                                                                            /
 */


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