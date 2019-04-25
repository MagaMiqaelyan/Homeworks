using System;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please input a phrase ");
            
            Func<string, string> acronym = delegate (string phrase) // Convert a phrase to its acronym. 
            {
                string res = Char.ToUpper(phrase[0]).ToString();

                for (int i = 1; i < phrase.Length; i++)
                {
                    if (!Char.IsLetter(phrase[i]))
                    {
                        res = String.Concat(res, Char.ToUpper(phrase[i + 1]));
                    }
                }
                return res;
            };

            Console.WriteLine(acronym(Console.ReadLine()));
        }
    }
}
