using System;
// Data Types and Variables - Lab
namespace _12._Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int sum = 0;
            int edit = 0;
            bool isSpecialNum = false;
            for (int ch = 1; ch <= input; ch++)
            {
                edit = ch;
                while (ch > 0)
                {
                    sum += ch % 10;
                    ch = ch / 10;
                }
                isSpecialNum = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine("{0} -> {1}", edit, isSpecialNum);
                sum = 0;
                ch = edit;
            }

        }
    }
}
