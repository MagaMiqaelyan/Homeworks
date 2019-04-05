using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the name of the venue");
            Venue venue = new Venue();
            venue.Name = Console.ReadLine();

            Band band = new Band();
            band.Name = Console.ReadLine();
            band.Genre = Console.ReadLine();
        }
    }
}
