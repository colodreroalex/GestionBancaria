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



    }
}
