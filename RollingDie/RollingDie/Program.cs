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
                Console.WriteLine("\nToss {0}", i); // Regular toss
                int[] contant = new int[5];
                EventOfDie die = new EventOfDie(contant);
                die.SumOfNumber += Die_SumOfNumber; // Subscribe to event that raise if the summary greater 20
                die.TwoFoursInRow += Die_TwoFoursInRow; // Subscribe to event that raise if there are two fours in a row

                die.Events(contant);
            }         
        }
        /// <summary>
        /// Attend an event that raise if there are two fours in a row
        /// </summary>
        /// <param name="count">Fours number count</param>
        private static void Die_TwoFoursInRow(int count)
        {
            Console.Write("\nTwo fours in a row ");
        }

        /// <summary>
        /// Attend an event that raise if the summary greater 20
        /// </summary>
        /// <param name="sum"></param>
        private static void Die_SumOfNumber(int sum)
        {
            Console.WriteLine("\n{0} is greater than 20 ", sum);
            
        }
    }
}
