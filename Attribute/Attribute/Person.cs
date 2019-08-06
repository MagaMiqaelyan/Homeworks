using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attribute
{
    public class Person
    {
        [DisplayAttribute (ConsoleColor.Red)]
        public string Name { get; set; }
        public int AgeInYears { get; set; }

        public Person(string Name, int AgeInYears)
        {
            this.AgeInYears = AgeInYears;
            this.Name = Name;
        }
    }
}
