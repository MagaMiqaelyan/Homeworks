using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attribute
{
    class Program
    {
        static void Main(string[] args)
        {
            Person myPerson = new Person("John", 71);
            PersonPrinter printer = new PersonPrinter(myPerson);
            printer.Print();
        }
    }
}
