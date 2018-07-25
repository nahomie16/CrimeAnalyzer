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
        static void Main(string[] args)
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

                IEnumerable<int> q2 = from crimeStats in crimeStatsList
                                      where crimeStats.year > 1
                                      select crimeStats.year; 
                



                IEnumerable<int> q3 = from crimeStats in crimeStatsList where crimeStats.robbery > 15000 select crimeStats.year;

         
                IEnumerable<int> q4 = from crimeStats in crimeStatsList where crimeStats.robbery > 500000 select crimeStats.year;


                IEnumerable<int> q10 = from crimeStats in crimeStatsList
                                       where crimeStats.motorVehicleTheft < 1200000 && crimeStats.rape > 89411
                                       select crimeStats.year;

                IEnumerable<int> sample = from crimeStats in crimeStatsList
                                       select crimeStats.murder;

                double avg = sample.Average(); 
                Console.WriteLine($"Average murder per year: {avg}" );
                Console.WriteLine("___________ ");



                IEnumerable<int> q8 = from crimeStats in crimeStatsList
                                      where crimeStats.murder > 2010 && crimeStats.murder > 2013 
                                      select crimeStats.year;  // add average 


                /// Average number of murders 
                IEnumerable<int> q6 = from crimeStats in crimeStatsList    
                                      select crimeStats.murder;

                /// Average number of murders for 1994 to 1997
                IEnumerable<int> q7 = from crimeStats in crimeStatsList
                                    where crimeStats.year > 1994 && crimeStats.year <= 1997
                                      select crimeStats.murder;

                double q6_average = q6.Average();
                Console.WriteLine($"Question q6 is {q6_average}"); 


                double q7_average = q6.Average();
                Console.WriteLine($"Question q6 is {q7_average}"); 

                Console.WriteLine("Years where rapes were less than 15000");

                foreach (int t in q10)
                { // loop through result from each Year where rapes were less than 85000
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
