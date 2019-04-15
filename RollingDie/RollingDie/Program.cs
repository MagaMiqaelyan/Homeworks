﻿using System;
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
            Console.WriteLine("Rolling a die");
            EventOfDie die = new EventOfDie();
            die.TwoFoursInRow += Die_TwoFoursInRow; // Subscribe to event that raise if there are two fours in a row
            die.SumOfNumber += Die_SumOfNumber; // Subscribe to event that raise if the summary greater 20
            die.Events(die);
                  
        }       
        
        /// <summary>
        /// Attend an event that raise if there are two fours in a row
        /// </summary>
        /// <param name="count">Fours number count</param>
        private static void Die_TwoFoursInRow()
        {
            Console.WriteLine("\nTwo fours in a row ");
        }

        /// <summary>
        /// Attend an event that raise if the summary greater 20
        /// </summary>
        /// <param name="sum"></param>
        private static void Die_SumOfNumber()
        {
            Console.WriteLine("\nSummary is greater than 20");
            
        }
    }
}
