using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accionlabsTest
{
    public static class Test1_recursion
    {
        //1) Write a program in C# Sharp to calculate the power of any number using recursion.
        //Recursion : Calculate power of any number :
        //------------------------------------------------
        //Input the base value : 2
        //Input the exponent : 6
        //The value of 2 to the power of 6 is : 64

        // 2 * (2 * (2 * (2 * (2 * 2))))

        public static void PrintRecursionValue()
        {

            Console.WriteLine("Input the base value");
            var baseValue = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Input the exponent Value");
            var exponentValue = Convert.ToInt32(Console.ReadLine());

            var res = GetExponent(baseValue, exponentValue);

            Console.WriteLine("The value of {0} to the power of {1} is : {2}", baseValue, exponentValue, res);
            Console.ReadLine();
        }

        private static int GetExponent(int baseValue, int exponentValue)
        {
            if (exponentValue == 1)
                return baseValue;

            return baseValue * GetExponent(baseValue, exponentValue - 1);
        }
    }
}
