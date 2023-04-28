using BGCuentas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBancaria
{
    public static class Gfichero
    {
        //Nombre de MI FICHERO
        const string FICHERO = "productos.sgb";

        public static void AgregarCuenta(Cuenta nuevaCuenta)
        {
            //RECURSOS
            string tipoCuenta = "";
            int edad = 0; 
            StreamWriter escritor = null; 

            //INICIALIZACION
            if (nuevaCuenta is CuentaJoven)
            {
               tipoCuenta = OTipoCuenta.Cuenta_Joven.ToString();    //Para la cuenta Joven la guardamos en el tipo de cuenta y convertimos con el .ToString, asi con todas(POLIMORFISMO)
                edad = ((CuentaJoven)nuevaCuenta).Edad;         //nuevaCuenta.Edad: No existe con lo cual tenemos que "edad" convertirla a la clase apropiada(cuentajoven)
                                                                //Se convierte nuevaCuenta --> CuentaJoven
            } 
            if (nuevaCuenta is CuentaOro)
            {
                tipoCuenta = OTipoCuenta.Cuenta_Oro.ToString();
                edad = ((CuentaOro)nuevaCuenta).Edad;
            }
            if (nuevaCuenta is CuentaPlatino)
            {
                tipoCuenta = OTipoCuenta.Cuenta_Platino.ToString();
                edad = ((CuentaPlatino)nuevaCuenta).Edad;
            }

            //EVALUAR EL TIPO DE APERTURA DEL FICHERO
            if (!File.Exists(FICHERO))  //Si el fichero no existe
            {
                escritor = File.CreateText(FICHERO);    //Lo creas
            }
            else
            {
               escritor = File.AppendText(FICHERO);     //Si existe, 
                
            }


            //AGREGAR LA CUENTA
            escritor.WriteLine(nuevaCuenta.Titular);
            escritor.WriteLine(edad);
            escritor.WriteLine(nuevaCuenta.Saldo);
            escritor.WriteLine(tipoCuenta);
            escritor.WriteLine("");

            //CERRAR LOS RECURSOS ASOCIADOS AL FICHERO
            escritor.Close();
        }
    }
}
