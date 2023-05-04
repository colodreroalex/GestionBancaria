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
        public static void ConsultarFcihero()
        {
            Console.WriteLine("");
            Console.Write("\tIntroduzca el nombre del fichero a consultar: ");
            string fichero = Console.ReadLine();

            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(fichero))
                {
                    string line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                    Console.ReadLine(); 
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }


        }
    }
}
