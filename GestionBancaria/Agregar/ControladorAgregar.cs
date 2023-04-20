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
        public static void AgregarCuenta(List<Cuenta> lista)
        {

            bool salir = false;
            AgregarCuenta cuenta = GestionBancaria.AgregarCuenta.Salir;
            Cuenta nuevaCuenta;      ///Nueva cuenta a agregar




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
                    case GestionBancaria.AgregarCuenta.Cuenta_Oro:
                    case GestionBancaria.AgregarCuenta.Cuenta_Platino:
                        nuevaCuenta  = CrearCuenta(cuenta);
                        lista.Add(nuevaCuenta);
                        break;
                }

                #region 1CUENTA
                //Llamada a un unico metodo
                //if (cuenta == GestionBancaria.AgregarCuenta.Salir) salir = true;

                //else
                //{
                //    nuevaCuenta = CrearCuenta(cuenta);

                //    if (nuevaCuenta != null)
                //    {
                //        lista.Add(nuevaCuenta);
                //        Interfaz.InformarAccion($"Agregar cuenta {cuenta}");
                //    }
                //    else Interfaz.InformarError("La cuenta no ha sido creada");

                //}
                #endregion


            } while (!salir);
        }




        //GENERAR UN METODO PARA TODOS LOS TIPOS - Cuando haya similitudes como en este caso
        public static Cuenta CrearCuenta(AgregarCuenta tipo)
        {

            Cuenta newCuenta = null;

            try
            {
                Console.WriteLine($"Ingrese el nombre para su cuenta: ");
                string nombre = Console.ReadLine();

                Console.WriteLine($"Ingrese la edad: ");
                int edad = Int32.Parse(Console.ReadLine());

                Console.WriteLine($"Ingrese la cantidad a ingresar en la cuenta: ");
                double cantidad = double.Parse(Console.ReadLine());

                switch (tipo)
                {
                    case GestionBancaria.AgregarCuenta.Cuenta_Joven:
                        newCuenta = new CuentaJoven(nombre, cantidad, edad);
                        break;
                    case GestionBancaria.AgregarCuenta.Cuenta_Oro:
                        newCuenta = new CuentaOro(nombre, cantidad, edad);
                        break;
                    case GestionBancaria.AgregarCuenta.Cuenta_Platino:
                        newCuenta = new CuentaPlatino(nombre, cantidad, edad);
                        break;

                }
            }

            catch (TitularException tx)
            {
                Interfaz.InformarError(tx.Message);
            }
            catch (EdadException ex)
            {
                Interfaz.InformarError(ex.Message);
            }
            catch (CantidadException ce)
            {
                Interfaz.InformarError(ce.Message);
            }
            catch (Exception exx)
            {
                Interfaz.InformarError(exx.Message);
            }



            return newCuenta;
        }

        //YO
        //public static Cuenta CapturarDatosCuenta(AgregarCuenta tipoCuenta)
        //{
        //    Console.WriteLine($"Ingrese nombre para su cuenta: ");
        //    string nombre = Console.ReadLine();

        //    Console.WriteLine("Ahora introduce la edad: ");
        //    int edad = Int32.Parse(Console.ReadLine());

        //    Console.WriteLine("Introduce la cantidad para esta cuenta (No puede estar vacia): ");
        //    double cantidad = Double.Parse(Console.ReadLine());

        //    switch (tipoCuenta)
        //    {
        //        case GestionBancaria.AgregarCuenta.Cuenta_Joven:
        //            return new CuentaJoven(nombre, cantidad, edad);
        //        case GestionBancaria.AgregarCuenta.Cuenta_Oro:
        //            return new CuentaOro(nombre, cantidad, edad);
        //        case GestionBancaria.AgregarCuenta.Cuenta_Platino:
        //            return new CuentaPlatino(nombre, cantidad, edad);
        //        default:
        //            throw new ArgumentException("Tipo de cuenta no válido.");
        //    }
        //}


    }
}

