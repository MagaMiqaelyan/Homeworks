using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollingDie
{
    class Program
    {        
        static void Main(string[] args)
        {
            for (int i = 1; i <= 50; i++)
            {
                Console.WriteLine("\nToss {0}", i);
                int[] contant = new int[5];
                EventOfDie die = new EventOfDie(contant);
                die.SumOfNumber += Die_SumOfNumber;
                die.TwoFoursInRow += Die_TwoFoursInRow;

                die.Events(contant);
            }         
        }
        private static void Die_TwoFoursInRow(int count)
        {
            Console.Write("\nTwo fours in a row ");
        }

        private static void Die_SumOfNumber(int sum)
        {
            Console.WriteLine("\n{0} is greater than 20 ", sum);
            
        }
    }
}
