using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace assignments1
{
    public class Complex
    {
        public double real;
        public double unreal;

        public Complex(double real, double unreal)
        {
            this.real = real;
            this.unreal = unreal;
        }
        public static Complex operator +(Complex one, Complex two)
        {
            return new Complex(one.real + two.real, one.unreal + two.unreal);
        }
        public static Complex operator -(Complex one, Complex two)
        {
            return new Complex(one.real - two.real, one.unreal - two.unreal);
        }
        public static Complex operator *(Complex one, Complex two)
        {
            return new Complex((one.real * two.real) - (one.unreal * two.unreal), (one.real * two.unreal) + (one.unreal * two.real));
        }
        public static Complex operator /(Complex one, Complex two)
        {
            double square = Math.Pow(two.real, 2) + Math.Pow(two.unreal, 2);
            double a = ((one.real * two.real) + (one.unreal * two.unreal)) / square;
            double b = ((one.unreal * two.real) - (one.real + two.unreal)) / square;
            return new Complex(a, b);
        }
        public static double AbsValue(Complex a)
        {
            return Math.Sqrt(a.real * a.real + a.unreal * a.unreal);
        }
        public override string ToString()
        {
            return (String.Format("{0} + {1}i", real, unreal));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Complex x = new Complex(6, 8);
            Complex y = new Complex(2, 4);
            Console.WriteLine("Add is " + (x + y));
            Console.WriteLine("Sub is " + (x - y));
            Console.WriteLine("Mul is " + (x * y));
            Console.WriteLine("Div is " + (x / y));
            Console.WriteLine("|x| = " + Complex.AbsValue(x));
            Console.WriteLine("|y| = " + Complex.AbsValue(y));
        }
    }
}
