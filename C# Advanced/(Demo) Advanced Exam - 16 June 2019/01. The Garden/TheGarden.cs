using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._The_Garden
{
    public class TheGarden
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            string[][] matrix = new string[rows][];

            for (int col = 0; col < rows; col++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                matrix[col] = input;
            }

            string inputCommand = Console.ReadLine();
            int countOfCarrots = 0;
            int countOfPotatos = 0;
            int countOfCucmbers = 0;
            int countOfHarmed = 0;

            while (inputCommand != "End of Harvest")
            {
                string[] tokens = inputCommand.Split(" ").ToArray();

                string command = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                if (command == "Harvest")
                {
                    if (isInside(matrix, row, col) && matrix[row][col] != " ")
                    {
                        switch (matrix[row][col])
                        {
                            case "P":
                                countOfPotatos++;
                                break;
                            case "C":
                                countOfCarrots++;
                                break;
                            case "L":
                                countOfCucmbers++;
                                break;
                        }

                        matrix[row][col] = " ";
                    }
                }
                else if (command == "Mole")
                {
                    string direction = tokens[3];
                    while (isInside(matrix, row, col) && matrix[row][col] !=" ")
                    { 
                        switch (direction)
                        {
                            case "up":
                                matrix[row][col] = " ";
                                countOfHarmed++;
                                row -= 2;
                                break;

                            case "down":
                                matrix[row][col] = " ";
                                countOfHarmed++;
                                row += 2;
                                break;

                            case "left":
                                matrix[row][col] = " ";
                                countOfHarmed++;
                                col -= 2;
                                break;

                            case "right":
                                matrix[row][col] = " ";
                                countOfHarmed++;
                                col += 2;
                                break;
                        }
                    }
                }

                inputCommand = Console.ReadLine();
            }

            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join(" ", item));
            }
            Console.WriteLine($"Carrots: {countOfCarrots}");
            Console.WriteLine($"Potatoes: {countOfPotatos}");
            Console.WriteLine($"Lettuce: {countOfCucmbers}");
            Console.WriteLine($"Harmed vegetables: {countOfHarmed}");

        }

        private static bool isInside(string[][] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }
    }
}