using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Attribute
{
    public  class PersonPrinter
    {
        public Person MyPerson { get; set; }

        public PersonPrinter(Person myPerson)
        {
            MyPerson = myPerson;
        }        

        public void Print()
        {
            PropertyInfo nameProperty = typeof(Person).GetProperty("Name");
            DisplayAttribute colorProperty = (DisplayAttribute)System.Attribute.GetCustomAttribute(nameProperty, typeof(DisplayAttribute));

            if (colorProperty != null)
            {
                Console.ForegroundColor = colorProperty.Color;
            }

            Console.WriteLine($"Person name is-{this.MyPerson.Name}");
            ResetColor();
            Console.WriteLine($"Person age is-{this.MyPerson.AgeInYears}");
        }

        private void ResetColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
