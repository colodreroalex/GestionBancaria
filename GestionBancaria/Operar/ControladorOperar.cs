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
            catch (BGCuentas.CantidadException err)
            {
                Interfaz.InformarError(err.Message);
            }

        }


    }
}
