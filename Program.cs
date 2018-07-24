using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace CrimeAnalyzer
{




    class Program
    {
        static void Main(string[] args)
        {
            string line;

            try
            {

                Console.WriteLine("Enter the File name:");

                string filename = Console.ReadLine();
                StreamReader sr = new StreamReader(filename);

                line = sr.ReadLine();
                Console.WriteLine(line);


            }

            catch (Exception e)
            {
                Console.WriteLine("Exception:" + e.Message);
            }

            finally
            {

                Console.WriteLine("final block");
            }

        }
    }
}
