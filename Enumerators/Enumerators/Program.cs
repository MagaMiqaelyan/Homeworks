using System;
using System.Collections.Generic;

namespace Enumerators
{
    class Program
    {
        static void Main(string[] args)
        {
            List<University> universities = new List<University>
            {
                new University("YSU", "Armenia"),
                new University("CAM", "UK"),
                new University("Harvard", "USA"),
                new University("Tsinghua", "China")
            };

            Universities universitieslist = new Universities(universities);

            foreach (University university in universitieslist)
            {
                Console.WriteLine(university.Name + " university is located in " + university.Place);
            }
            Console.WriteLine();
        }
    }
}
