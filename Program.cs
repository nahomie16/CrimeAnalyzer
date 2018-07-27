using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace CrimeAnalyzer
{


    class CrimeStats
    {

        public int year;
        public int population;
        public int violentCrime;
        public int murder;
        public int rape;
        public int robbery;
        public int aggravatedAssault;
        public int propertyCrime;
        public int burglary;
        public int theft;
        public int motorVehicleTheft;



        public CrimeStats(int year, int population, int violentCrime, int murder, int rape, int robbery, int aggravatedAssault, int propertyCrime, int burglary, int theft, int motorVehicleTheft)
        {
            this.year = year;
            this.population = population;
            this.violentCrime = violentCrime;
            this.murder = murder;
            this.rape = rape;
            this.robbery = robbery;
            this.aggravatedAssault = aggravatedAssault;
            this.propertyCrime = propertyCrime;
            this.burglary = burglary;
            this.theft = theft;
            this.motorVehicleTheft = motorVehicleTheft;
        }

    }



    class Program
    {
        public static void Main(string[] args)
        {
            string line;

            try
            {



                List<CrimeStats> crimeStatsList = new List<CrimeStats>();


                //Console.WriteLine("Enter the File name:");
                /// string filename = Console.ReadLine();

                string filename = args[0] ; // csv file 

                //Console.WriteLine("Enter the report filename:");
                // string report = Console.ReadLine();

                string report = args[1]; // report file 

                StreamWriter sw = new  StreamWriter(report);




            
                StreamReader sr = new StreamReader(filename);

                /// read first line 
                line = sr.ReadLine();

     
                // Second line where data starts 
                line = sr.ReadLine();

                while (line != null)
                {

                    string[] columns = line.Split(',');  // columns[0] == year columns[1] == population columns[2] == Violent Crime


                    int year = Convert.ToInt32(columns[0]);
                    int population = Convert.ToInt32(columns[1]);
                    int violentCrime = Convert.ToInt32(columns[2]);
                    int murder = Convert.ToInt32(columns[3]);
                    int rape = Convert.ToInt32(columns[4]);
                    int robbery = Convert.ToInt32(columns[5]);
                    int aggravatedAssault = Convert.ToInt32(columns[6]);
                    int propertyCrime = Convert.ToInt32(columns[7]);
                    int burglary = Convert.ToInt32(columns[8]);
                    int theft = Convert.ToInt32(columns[9]);
                    int motorVehicleTheft = Convert.ToInt32(columns[10]);

                    // Read next line 
                    line = sr.ReadLine();

                    CrimeStats crimeStats = new CrimeStats(year, population, violentCrime, murder, rape, robbery, aggravatedAssault, propertyCrime, burglary, theft, motorVehicleTheft);

                    crimeStatsList.Add(crimeStats);


                }

                // What is the range of years included in the data?
                IEnumerable<int> q1 = from crimeStats in crimeStatsList
                                      where crimeStats.year >= 1994 && crimeStats.year < 2014
                                      select crimeStats.year;

                Console.WriteLine($"Period {q1.Min()} - {q1.Max()}  ({q1.Max() - q1.Min()} years)");
                sw.WriteLine($"Period {q1.Min()} - {q1.Max()}  ({q1.Max() - q1.Min()} years)");


                 
                // How many years of data are included?
                IEnumerable<int> q2 = from crimeStats in crimeStatsList
                                      select crimeStats.year;

                Console.WriteLine($"Year count {q2.Count()}");
                sw.WriteLine($"Year count {q2.Count()}"); 


                // What years is the number of murders per year less than 15000?
                IEnumerable<int> q3 = from crimeStats in crimeStatsList
                                      where crimeStats.murder < 15000
                                      select crimeStats.year;
                
                Console.Write($"Years murders per year< 15000: ");
                sw.Write($"Years murders per year< 15000: ");


                foreach (int x in q3)
                {
                    Console.Write($"{x}, ");
                    sw.Write($"{x}, ");

                }

                Console.WriteLine("\n");
                sw.WriteLine("\n");


                // What are the years and associated robberies per year for years where the number of robberies is greater than 500000 ?
                IEnumerable<int> q4 = from crimeStats in crimeStatsList
                                      where crimeStats.robbery > 500000
                                      select crimeStats.year;

                Console.Write("Robberies per year > 500000 "); 
                sw.Write("Robberies per year > 500000 "); 


                foreach (int x in q4)
                {
                    Console.Write($"{x}, ");
                    sw.Write($"{x}, ");

                }
                
                Console.WriteLine("\n");
                sw.WriteLine("\n");


          

                // What is the violent crime per capita rate for 2010? Per capita rate is the number of violent crimes in a year divided by the size of the population that year.

                IEnumerable<double> q5 = from crimeStats in crimeStatsList
                                         where crimeStats.year == 2010
                                         select crimeStats.violentCrime / (double)crimeStats.population;


                Console.Write("Violent crime per capita rate(2010): ");  
                sw.Write("Violent crime per capita rate(2010): ");  

                foreach (double x in q5)
                {
                    Console.Write(x);
                    sw.Write(x);


                }
                Console.WriteLine("\n");
                sw.WriteLine("\n");


                // What is the average number of murders per year across all years? 
                IEnumerable<int> q6 = from crimeStats in crimeStatsList
                                      select crimeStats.murder;


                double avg_murder = q6.Average();
                Console.WriteLine($"Average murder per year (all years):  {avg_murder}");
                sw.WriteLine($"Average murder per year (all years):  {avg_murder}");



                // What is the average number of murders per year for 1994 to 1997?
                IEnumerable<int> q7 = from crimeStats in crimeStatsList
                                      where crimeStats.year >= 1994 && crimeStats.year <= 1997
                                      select crimeStats.murder;

                double avg_murder2 = q7.Average();
                Console.WriteLine($"Average murder per year (1994-1997) {avg_murder2}");
                sw.WriteLine($"Average murder per year (1994-1997) {avg_murder2}");


                // What is the average number of murders per year for 2010 to 2013?
                IEnumerable<int> q8 = from crimeStats in crimeStatsList
                                      where crimeStats.year >= 2010 && crimeStats.year <= 2013
                                      select crimeStats.murder;

                double avg_murder3 = q8.Average();
                Console.WriteLine($"Average murder per year (2010-2013) {avg_murder3}"); 
                sw.WriteLine($"Average murder per year (2010-2013) {avg_murder3}");


                // What is the minimum number of thefts per year for 1999 to 2004?
                IEnumerable<int> q9 = from crimeStats in crimeStatsList
                                      where crimeStats.year >= 1999 && crimeStats.year <= 2004
                                      select crimeStats.theft;


                Console.WriteLine($"Minimum thefts per year (1999-2004): {q9.Min()}");
                sw.WriteLine($"Minimum thefts per year (1999-2004): {q9.Min()}");



                // QUESTION 10  What is the maximum number of thefts per year for 1999 to 2004 ?  
                Console.WriteLine($"Maximum thefts per year (1999-2004): {q9.Max()}");
                sw.WriteLine($"Maximum thefts per year (1999-2004): {q9.Max()}");


                // What year had the highest number of motor vehicle thefts?


                IEnumerable<int> q11 = from crimeStats in crimeStatsList
                                       where crimeStats.motorVehicleTheft > 1
                                       select crimeStats.motorVehicleTheft;




                int highest_murder = q11.Max();

                // get year 
                IEnumerable<int> q11_1 = from crimeStats in crimeStatsList
                                         where crimeStats.motorVehicleTheft == highest_murder
                                         select crimeStats.year;

                foreach (int x in q11_1)
                {

                    sw.WriteLine($"Year of highest number of motor vehicle thefts {x}");
                    break;
                }




                sr.Close();
                sw.Close(); 


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
