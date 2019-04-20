using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Seize_the_Fire
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            High = 89#Meduim = 53#Low = 28#Medium = 77#Low = 23
            1250
            */
            string inputLine = Console.ReadLine(); //.Split("#").ToString();
            int water = int.Parse(Console.ReadLine());
            string[] command = inputLine
                .Split(new char[] { '=', '#', ' ' }
                    , StringSplitOptions.RemoveEmptyEntries);

            double fire = 0;
            double effort = 0;
            List<double> cells = new List<double>();

            for (int i = 0; i < command.Length; i += 2)
            {
                int valueOfCell = int.Parse(command[i + 1]);
                string typeOfFire = command[i];
                if ((water - valueOfCell) < 0)
                {
                    break;
                }
                if (typeOfFire == "High" && (valueOfCell >= 81 && valueOfCell <= 125))
                {
                    fire += valueOfCell;
                    effort += valueOfCell * 0.25;
                    cells.Add(valueOfCell);
                    water -= valueOfCell;
                }
                else if (typeOfFire == "Medium" && (valueOfCell >= 51 && valueOfCell <= 80))
                {
                    fire += valueOfCell;
                    effort += valueOfCell * 0.25;
                    cells.Add(valueOfCell);
                    water -= valueOfCell;
                }
                else if (typeOfFire == "Low" && (valueOfCell >= 1 && valueOfCell <= 50))
                {
                    fire += valueOfCell;
                    effort += valueOfCell * 0.25;
                    cells.Add(valueOfCell);
                    water -= valueOfCell;
                }
            }

            Console.WriteLine("Cells:");
            foreach (var cell in cells)
            {
                Console.WriteLine($" - {cell}");
            }

            Console.WriteLine($"Effort: {effort:f2}");
            Console.WriteLine($"Total Fire: {fire}");
        }
    }
}
