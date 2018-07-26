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


                Console.WriteLine("Enter the File name:");
                string filename = "CrimeData.csv";

                Console.WriteLine("Enter the report filename:");
                string report;

                /// string filename = Console.ReadLine();
                StreamReader sr = new StreamReader(filename);

                /// read first line 
                line = sr.ReadLine();

                string[] titles = line.Split(',');  // Years Population , etc 


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
                                      where crimeStats.year <= 2013 && crimeStats.year >= 1994
                                      select crimeStats.year; 

                Console.WriteLine($"Period {q1.Min()} - {q1.Max()}  ({q1.Max() - q1.Min()} years)"); 


                // How many years of data are included?
                IEnumerable<int> q2 = from crimeStats in crimeStatsList
                                      where crimeStats.year > 1
                                      select crimeStats.year;

                Console.WriteLine(q2.Count()); 


                // What years is the number of murders per year less than 15000?
                IEnumerable<int> q3 =   from crimeStats in crimeStatsList 
                                         where crimeStats.murder < 15000
                                        select crimeStats.year;
                foreach(int y in q3 ){

                    Console.WriteLine(y); 
                }
                Console.WriteLine(" -------------------");

                // What are the years and associated robberies per year for years where the number of robberies is greater than 500000 ?
                IEnumerable<int> q4 = from crimeStats in crimeStatsList
                                      where crimeStats.robbery > 500000
                                      select crimeStats.year;

                foreach(int y in q4 ){
                    
                    Console.WriteLine(y);
                }


                // What is the average number of murders per year across all years? 
                IEnumerable<int> q6 = from crimeStats in crimeStatsList
                                      select crimeStats.murder;


                double avg_murder = q6.Average(); 
                Console.WriteLine($"What is the average number of murders per year across all years ? {avg_murder}");

                // What is the average number of murders per year for 1994 to 1997?

                IEnumerable<int> q7 = from crimeStats in crimeStatsList
                                      where crimeStats.year >= 1994 && crimeStats.year <= 1997 
                                      select crimeStats.murder;



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
