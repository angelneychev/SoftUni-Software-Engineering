using System;

namespace _08._Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int allCubics = width * lenght * height;
            int currentCubics = 0;
            int sumCubics = 0;
            string command = Console.ReadLine();

            while (command != "Done")
            {
                int currentCubic = int.Parse(command);
                sumCubics += currentCubic;
                if (allCubics < sumCubics)
                {
                    int neededCubics = sumCubics - allCubics;
                    Console.WriteLine($"No more free space! You need {neededCubics} Cubic meters more.");
                    break;
                }

                command = Console.ReadLine();
            }
            if (command == "Done")
            {
                int moreCubecsLeft = allCubics - sumCubics;
                Console.WriteLine($"{moreCubecsLeft} Cubic meters left.");
            }

        }
    }
}
