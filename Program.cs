using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace CrimeAnalyzer
{



    class CrimeStats
    {


        private List<int> Rape = new List<int>();


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


                Console.WriteLine(line);


                string[] titles = line.Split(',');  // Years Population , etc 

                line = sr.ReadLine();


                List<int> Year = new List<int>();
                List<int> Population = new List<int>();
                List<int> Violent_Crime = new List<int>();
                List<int> Murder = new List<int>();
                List<int> Rape = new List<int>();
                List<int> Robbery = new List<int>();
                List<int> Aggravated_Assault = new List<int>();
                List<int> Property_Crime = new List<int>();
                List<int> Burglary = new List<int>();
                List<int> Theft = new List<int>();
                List<int> Motor_Vehicle_Theft = new List<int>();
              


                while (line != null)
                {
                    string[] columns = line.Split(',');  // columns[0] == year columns[1] == population columns[2] == Violent Crime

                    Year.Add(Convert.ToInt32(columns[0]));
                    Population.Add(Convert.ToInt32(columns[1]));
                    Violent_Crime.Add(Convert.ToInt32(columns[2]));
                    Murder.Add(Convert.ToInt32(columns[3]));
                    Rape.Add(Convert.ToInt32(columns[4]));
                    Robbery.Add(Convert.ToInt32(columns[5]));
                    Aggravated_Assault.Add(Convert.ToInt32(columns[6]));
                    Property_Crime.Add(Convert.ToInt32(columns[7]));
                    Burglary.Add(Convert.ToInt32(columns[8]));
                    Theft.Add(Convert.ToInt32(columns[9]));
                    Motor_Vehicle_Theft.Add(Convert.ToInt32(columns[10]));


                    line = sr.ReadLine();


                }


                //foreach(int t in yearList) { // loop through each year 
                //     Console.WriteLine(t);
                //}


                IEnumerable<int> q1 = from y in Year
                                      where y > 1997
                                      select y;

                Console.WriteLine("Years greater than 1997: ");

                foreach (int t in q1)
                { // loop through each IEnumerable result ("select year where its greater than 1997") 
                    Console.WriteLine(t);
                }

                sr.Close();

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
