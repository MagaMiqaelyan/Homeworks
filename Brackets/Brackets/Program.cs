using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brackets
{
    class Program
    {
        public static bool Check(char a, char b)
        {
            if (a == '(' && b == ')')
                return true;
            if (a == '[' && b == ']')
                return true;
            if (a == '{' && b == '}')
                return true;
            else return false;

        }
        public static bool IsBalanced(string str)
        {
            char[] OpBrackets = { '(', '[', '{' };
            char[] ClBrackets = { ')', ']', '}' };
            char[] brackets = new char[5];
            int i = 0;
            try
            {
                foreach (char c in str)
                {
                    if (OpBrackets.Contains(c))
                    {
                        brackets[i] = c;
                        i++;
                    }
                    else if (ClBrackets.Contains(c))
                    {
                        if (Check(brackets[i - 1], c))
                        {
                            brackets[i - 1] = '0';
                            i--;
                        }
                        else
                            return false;
                    }
                    else
                        continue;
                }
            }
            catch
            {
                return false;
            }
            return brackets.First() == '0' ? true : false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(IsBalanced("{}([[]()])"));
        }
    }
}
