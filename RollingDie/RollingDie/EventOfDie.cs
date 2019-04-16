using System;
using System.Collections.Generic;

namespace RollingDie
{
    class EventOfDie
    {
        public delegate void Rollingdie(); // Declare delegate 
        public event Rollingdie TwoFoursInRow; // Declare event of type delegate
        public event Rollingdie SumOfNumber; // Declare event of type delegate

        /// <summary>
        /// Event is happened
        /// </summary>
        /// <param name="die">Die numbers' list</param>
        public void Events(List<int> die)
        {
            Random random = new Random();

            for (int i = 0; i < 50; ++i)
            {
                die.Add(random.Next(1, 7)); // Rolling a die

                if (i > 0 && TwoFoursInRow != null && die[i - 1] == 4 && die[i] == 4) // Check if there are two numbers in row
                {
                    Console.Write(die[i - 1] + " " + die[i]);
                    this.TwoFoursInRow(); // Raise event
                }

                if (die.Count >= 5 && SumOfNumber != null && Sum(die, i - 4, i)) 
                {
                    for (int k = i - 4; k <= i; ++k)
                    {
                        Console.Write(die[k] + " ");
                    }
                    this.SumOfNumber(); // Raise event
                }
                else Console.Write(die[i] + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Count summary and compare with 20
        /// </summary>
        /// <param name="Sum">Sequence of numbers</param>
        /// <param name="start">First number</param>
        /// <param name="end">Last number</param>
        /// <returns>True if summary greater 20 or equal 20 ans false otherwise</returns>
        private bool Sum(List<int> Sum, int start, int end)
        {
            int sum = 0;
            for (int i = start; i <= end; ++i)
            {
                sum += Sum[i];
            }
            if (sum >= 20)
            {
                return true;
            }
            else return false;
        }

    }
}
