using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollingDie
{
    class EventOfDie
    {   
        private int[] Die { get; set; }
        public delegate void Rollingdie(); // Declare delegate 
        public event Rollingdie TwoFoursInRow; // Declare event of type delegate
        public event Rollingdie SumOfNumber; // Declare event of type delegate

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="die">Die numbers' array</param>
        public EventOfDie()
        {
            Die = new int[50];
            Random random = new Random();
            for (int j = 0; j < 50; j++)
            {
                this.Die[j] = random.Next(1, 7);             
            }           
        }
              
        public int this[int i]
        {
            get
            {
                return this.Die[i];
            }
            set
            {
                this.Die[i] = value;
            }
        }

        /// <summary>
        /// Event is happened
        /// </summary>
        /// <param name="die">Die numbers' array</param>
        public void Events(EventOfDie die)
        {
            for (int i = 0; i < 50; i++)
            {
                if (TwoFoursInRow != null && i < 49 && die[i] == 4 && die[i + 1] == 4)
                {
                    Console.Write(die[i] + " " + die[i + 1]);
                    this.TwoFoursInRow();
                }

                if (SumOfNumber != null && i < 45 && Sum(i, i + 5, die))
                {
                    for (int k = i; k < i + 5; k++)
                    {
                        Console.Write(die[k] + " ");
                    }
                    this.SumOfNumber();

                }
                else Console.Write(die[i] + " ");
            }
        }

        /// <summary>
        /// Count summary
        /// </summary>
        /// <param name="start">First number index</param>
        /// <param name="end">Last number index</param>
        /// <param name="die">Sequence of numbers</param>
        /// <returns></returns>
        private bool Sum(int start, int end, EventOfDie die)
        {
            int sum = 0;
            for (int i = start; i < end; i++)
            {
                sum += die[i];
            }
            if (sum >= 20)
            {
                return true;
            }
            else return false;
        }

    }
}
