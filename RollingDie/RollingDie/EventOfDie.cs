using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollingDie
{
    class EventOfDie
    {        
        public delegate void Rollingdie(int contant);
        public event Rollingdie TwoFoursInRow; // The row has two 4 number
        public event Rollingdie SumOfNumber; // The sum of numbers

        public EventOfDie(int[] die)
        {            
            Random random = new Random();
            for (int j = 0; j < die.Length; j++)
            {
                die[j] = random.Next(1, 7);
            }
                Print(die);            
        }
         public void Events(int[] die)
         {            

            if (TwoFoursInRow != null && TwoNumbers(die) == 2)
            {
                this.TwoFoursInRow(TwoNumbers(die));
            }

            if (SumOfNumber != null && Sum(die) >= 20)
            {
                this.SumOfNumber(Sum(die));
            }
         }

        /// <summary>
        /// Check if die shows two fours in a row
        /// </summary>
        /// <param name="arr">Die</param>
        /// <returns></returns>
        private int TwoNumbers(int[] die)
        {
            int count = 0;
            for (int i = 0; i < die.Length; i++)
            {
                if (die[i]==4)
                {
                    count++;
                }
            }
            return count;     
        }

        /// <summary>
        /// Count summary of the numbers
        /// </summary>
        /// <param name="die">Die</param>
        /// <returns></returns>
        private int Sum(int[] die)
        {
            int sum = 0;
            for (int i = 0; i < die.Length; i++)
            {
                sum += die[i];
            }
            return sum;
        }

        public void Print(int[] die)
        {
            for (int i = 0; i < die.Length; i++)
            {
                Console.Write(die[i] + " ");
            }
        }

    }
}
