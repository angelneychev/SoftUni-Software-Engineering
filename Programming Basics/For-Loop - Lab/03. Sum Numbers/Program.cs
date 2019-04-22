using System;

namespace _03._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= n; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());
                sum += currentNum;

            }
            Console.WriteLine(sum);
        }
    }
}
