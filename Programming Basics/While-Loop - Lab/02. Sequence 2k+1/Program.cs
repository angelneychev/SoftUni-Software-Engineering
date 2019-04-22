using System;

namespace _02._Sequence_2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int num = 1;

            while (num <= number)
            {
                Console.WriteLine(num);
                num = num * 2 + 1;
            }
        }
    }
}
