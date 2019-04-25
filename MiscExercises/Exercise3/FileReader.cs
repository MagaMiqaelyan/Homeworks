using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    class FileReader
    {
        private string fileName;
        /// <summary>
        /// Parameterless Constructor
        /// </summary>
        public FileReader()
        {

        }

        /// <summary>
        /// Parameterfull Constructor
        /// </summary>
        /// <param name="fileName"></param>
        public FileReader(string fileName)
        {
            this.fileName = fileName;
        }

        public List<Airport> File(string fileName)
        {
            var airports = new List<Airport>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (! reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] columns = line.Split(' ');
                    Airport airport = new Airport()
                    {
                        Name = columns[0],
                        CountryCode = columns[1],
                        Size = columns[2],
                    };
                    airports.Add(airport);
                }
            };
            return airports;
        }
    }
}
