using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[5];
            AddElement(arr, 8); // IndexOutOfRangeException
            // Division(4, 0); // DivideByZeroException
            try
            {
                Client client = new Client(10, "Anna");
                client.Add(10, "Armen");
            }
            catch (ClientException ex)
            {
                Console.WriteLine(ex.Message);
            }
            // My exception
           
            //Console.WriteLine(client.FindClient(15));
            //Console.WriteLine(client.FindClient(12));
           // client.Add(10, "Tigran");


        }


        /// <summary>
        /// Add elements in the array
        /// </summary>
        /// <param name="array"> Array </param>
        /// <param name="count"> Elements count </param>
        public static void AddElement(int[] array, int count)
        {
            Random random = new Random();
            try
            {
                for (int i = 0; i < count; i++)
                {
                    array[i] = random.Next(1, 10);
                }               
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("{0}", ex);
                throw ex;
            }
        }

        /// <summary>
        /// Divide two numbers
        /// </summary>
        /// <param name="num1"> Divided </param>
        /// <param name="num2"> Divisor </param>
        public static void Division(int num1, int num2)
        {
            int result = 0;
            try
            {
                result = num1 / num2;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Exception caught: {0}", e);
            }
            finally
            {
                Console.WriteLine("Result: {0}", result);
            }
        }
    }
    
}
