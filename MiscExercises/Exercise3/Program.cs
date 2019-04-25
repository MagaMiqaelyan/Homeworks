using System;
using System.Collections.Generic;

namespace Exercise3
{
    class Program
    {
        private static string file = "Test data for Exercise 3.txt";
        static void Main(string[] args)
        {
            var reader = new FileReader();
            List<Airport> airports = reader.File(file);

            Sort(airports);
            foreach (var item in airports)
            {
                Console.WriteLine("Name: {0}   Country Code: {1}   Size: {2}", item.Name, item.CountryCode, item.Size);
            }
        }
        
        /// <summary>
        /// Sorting airports with size
        /// </summary>
        /// <param name="airports"></param>
        static public void Sort(List<Airport> airports)
        {
            foreach (var item in airports)
            {
                switch (item.Size)
                {
                    case "Small":
                        {
                            item.AirportSize = 0;
                            break;
                        }
                    case "Medium":
                        {
                            item.AirportSize = 1;
                            break;
                        }
                    case "Large":
                        {
                            item.AirportSize = 2;
                            break;
                        }
                    case "Mega":
                        {
                            item.AirportSize = 3;
                            break;
                        }
                    case "SuperMega":
                        {
                            item.AirportSize = 4;
                            break;
                        }
                    default:
                        break;
                }
            }
            for (int i = 0; i < airports.Count - 1; ++i) 
            {
                for (int j = 0; j < airports.Count - i - 1; ++j) 
                {
                    if (airports[j].AirportSize > airports[j + 1].AirportSize) 
                    {
                        var temp = airports[j];
                        airports[j] = airports[j + 1];
                        airports[j + 1] = temp;
                    }
                }
            }            
        }
    }
}
