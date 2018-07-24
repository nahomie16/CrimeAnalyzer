using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace CrimeAnalyzer
{



    class CrimeStats { 
    
        
        private List <int> Rape = new List<int>();
    
    
    }
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

                /// read first line 
                line = sr.ReadLine();

              
                string[] titles = line.Split(',');
                line = sr.ReadLine();


                List<string> yearList = new List<string>();
                List<string> Population = new List<string>(); 
                 
                while (line != null) {
                    string [] columns = line.Split(',');  // columns[0] == year columns[1] == population columns[2] == Violent Crime

                    yearList.Add(columns[0]);
                    Population.Add(columns[1]); 
                    line = sr.ReadLine();

                    
                }


                foreach(string t in yearList) { 
                     Console.WriteLine(t);
                }




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
