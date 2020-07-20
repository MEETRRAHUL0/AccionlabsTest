using System;

namespace accionlabsTest
{
    public static class Test5_Reverse_string
    {
        //5) Reverse a string without affecting special characters
        //Input: str = "a,b$c"
        //Output: str = "c,b$a"

        //Note that $ and , are not moved anywhere.
        //Only subsequence " abc" is reversed

        // Input: str = "Ab,c,de!$"
        //Output: str = "ed,c,bA!$"

        public static void Start()
        {

            Console.WriteLine("Input String");
            var str = Console.ReadLine();

            var result = ReverseString(str);

            Console.Write(" Reverse od {0} is  {1}", str, result);
            Console.ReadLine();
        }

        private static string ReverseString(string inputStr)
        {
            int end = inputStr.Length - 1;
            int start = 0;
            char[] str = inputStr.ToCharArray();

            while (start < end)
            {
                if (!char.IsLetter(str[start]))
                    start++;

                if (!char.IsLetter(str[end]))
                    end--;

                var t = str[start];
                str[start] = str[end];
                str[end] = t;

                start++;
                end--;
            }

            return string.Join("", str);

        }
    }
}
