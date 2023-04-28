using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBancaria
{
    public static partial class Interfaz
    {
        public static void MenuAgregarCuenta()
        {
            Console.Clear();
            Console.WriteLine("");
            //Console.WriteLine("\t1.-Cuenta General");
            Console.WriteLine("\t0.-Salir");
            Console.WriteLine("\t1.-Cuenta Joven");
            Console.WriteLine("\t2.-Cuenta Oro");
            Console.WriteLine("\t3.-Cuenta Platino\n");
        }

        public static OTipoCuenta OpcionMenuAgregar()
        {

            //RECURSOS 
            OTipoCuenta cuenta = OTipoCuenta.Salir;
            bool opcionCorrecta;

            do
            {
                opcionCorrecta = false;
                //Mostrar Menu de tipo de Cuentas
                MenuAgregarCuenta();
                //SELECCIONAR EL TIPO DE CUENTA
                try
                {
                    cuenta = (OTipoCuenta)LeerOpcion((byte)OTipoCuenta.Salir, (byte)OTipoCuenta.Cuenta_Platino);
                    opcionCorrecta = true;
                }
                catch (Exception err)
                {
                    InformarError(err.Message);
                }

            } while (!opcionCorrecta);

            return cuenta;
        }
    }
}
