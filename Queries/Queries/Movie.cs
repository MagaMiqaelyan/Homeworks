using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries
{
    class Movie
    {
        public string Title { get; set; }
        public float Rating { get; set; }
        private int year;
        public int Year
        {   get
            {
                Console.WriteLine($"Getting the year {this.year}");
                return this.year;
            }
            set
            {
                this.year = value;
            }
        }
    }
}
