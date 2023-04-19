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
        static void ModificarCuenta(List<Cuenta> lista)
        {
            int indiceCuenta = 0;
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




        }



    }
}
