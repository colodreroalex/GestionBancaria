using BGCuentas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBancaria
{
    public static partial class Controlador
    {
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
                    Interfaz.MostrarDatosCuenta(lista[indice]);

                }
                //IMPORTANTE
                else salir = true;

            } while (!salir);
            //Seleccionar la cuenta a Consultar

            //Ejecutar la opcion - Consultar la cuenta
        }
    }
}
