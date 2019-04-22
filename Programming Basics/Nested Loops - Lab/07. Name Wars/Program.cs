using System;

namespace _07._Name_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string bestName = string.Empty;
            int sumAll = 0;

            while (name != "STOP")
            {
                int sum = 0;

                for (int i = 0; i < name.Length; i++)
                {
                    sum += name[i];

                }
                if (sum > sumAll)
                {
                    sumAll = sum;
                    bestName = name;
                }
                name = Console.ReadLine();
            }
            Console.WriteLine($"Winner is {bestName} - {sumAll}!");
        }
    }
}
