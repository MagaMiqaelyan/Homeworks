using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concert
{
    class Band
    {
       // List<Musician> Musicians;
        public string Name { get; set; }
        public string Genre { get; set; }
        public List<Musician> MusiciansList { get; set; }

    }
}
