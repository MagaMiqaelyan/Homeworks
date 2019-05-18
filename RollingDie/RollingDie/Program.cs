using System;
using System.Collections.Generic;

namespace RollingDie
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Rolling a die");
            EventOfDie die = new EventOfDie();
            List<int> list = new List<int>();
            die.TwoFoursInRow += Die_TwoFoursInRow; // Subscribe to event that raise if there are two fours in a row
            die.TwoFoursInRow += Die_TwoFoursInRow2; // Subscribe to event that raise if there are two fours in a row
            die.SumOfNumber += Die_SumOfNumber; // Subscribe to event that raise if the summary greater 20
            die.Events(list);

        }

        /// <summary>
        /// Attend an event that raise if there are two fours in a row
        /// </summary>        
        private static void Die_TwoFoursInRow()
        {
            Console.WriteLine("\nTwo fours in a row ");
        }

         private static void Die_TwoFoursInRow2()
        {
            Console.WriteLine("\nTwo fours in a row 2");
        }

        /// <summary>
        /// Attend an event that raise if the summary greater 20
        /// </summary>
        private static void Die_SumOfNumber()
        {
            Console.WriteLine("\nSummary is greater than 20 or equal 20");

        }
    }
}
