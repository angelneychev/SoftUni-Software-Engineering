using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Seize_the_Fire
{
    class Program
    {
        static void Main()
        {
            string[] inputLine = Console.ReadLine().Split("#");
            int water = int.Parse(Console.ReadLine());
            double effort = 0;
            List<double> cells = new List<double>();
            for (int i = 0; i < inputLine.Length; i++)
            {
                string[] command = inputLine[i].Split(" = ");
                string typeOfFire = command[0];
                int valueOfCell = int.Parse(command[1]);
                if (water < valueOfCell)
                {
                    continue;
                }
                if (typeOfFire == "High" && (valueOfCell >=81 && valueOfCell <=125))
                {
                    cells.Add(valueOfCell);
                    water -= valueOfCell;
                    effort += valueOfCell * 0.25;
                }
                else if (typeOfFire == "Medium" && (valueOfCell >= 51 && valueOfCell <= 80))
                {
                    cells.Add(valueOfCell);
                    water -= valueOfCell;
                    effort += valueOfCell * 0.25;
                }
                else if (typeOfFire == "Low" && (valueOfCell >= 1 && valueOfCell <= 50))
                {
                    cells.Add(valueOfCell);
                    water -= valueOfCell;
                    effort += valueOfCell * 0.25;
                }
            }

            Console.WriteLine("Cells:");
            foreach (var cell in cells)
            {
                Console.WriteLine($" - {cell:f0}");
            }

            Console.WriteLine($"Effort: {effort:f2}");

            Console.WriteLine($"Total Fire: {cells.Sum():f0}");
        }
    }
}
