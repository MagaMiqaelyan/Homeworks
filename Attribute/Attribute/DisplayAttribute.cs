using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attribute
{
    public class DisplayAttribute : System.Attribute
    {
        public ConsoleColor Color { get; set; }
        public DisplayAttribute(ConsoleColor color)
        {
            this.Color = color;
        }
    }
}
