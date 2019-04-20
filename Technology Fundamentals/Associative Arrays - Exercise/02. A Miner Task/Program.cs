using System;
using System.Collections.Generic;

namespace _02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
           // int number = int.Parse(Console.ReadLine());
            var dictionary = new Dictionary<string, int>();
            while (inputString !="stop")
            {
                int number = int.Parse(Console.ReadLine());

                if (!dictionary.ContainsKey(inputString))
                {
                    dictionary[inputString] = number;
                }
                else
                {
                    dictionary[inputString] += number;
                }

                inputString = Console.ReadLine();
            }

            foreach (var kpv in dictionary)
            {
                Console.WriteLine($"{kpv.Key} -> {kpv.Value}");
            }

        }
    }
}
