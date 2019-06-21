using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Helens_Abduction
{
    public class HelensAbduction
    {
        static void Main()
        {
            int energy = int.Parse(Console.ReadLine());
            int rowsCount = int.Parse(Console.ReadLine());
            var parisRow = -1;
            var parisCol = -1;
            var helenaRow = -1;
            var helenaCol = -1;

            char[][] matrix = new char[rowsCount][];

            for (int col = 0; col < rowsCount; col++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                matrix[col] = currentRow;
                if (matrix[col].Contains('P'))
                {
                    parisCol = Array.IndexOf(matrix[col], 'P');
                    parisRow = col;
                }

                if (matrix[col].Contains('H'))
                {
                    helenaCol = Array.IndexOf(matrix[col], 'H');
                    helenaRow = col;
                }
            }

            matrix[parisRow][parisCol] = '-';

            while (true)
            {
                string[] commands = Console.ReadLine().Split(" ").ToArray();
                string command = commands[0];
                int spartanRow = int.Parse(commands[1]);
                int spartanCol = int.Parse(commands[2]);

                matrix[spartanRow][spartanCol] = 'S';

                if (command == "up")
                {
                    if (parisRow - 1 >= 0)
                    {
                        parisRow--;
                    }
                }
                else if (command == "down")
                {
                    if (parisRow + 1 < matrix.Length)
                    {
                        parisRow++;
                    }
                }
                else if (command == "left")
                {
                    if (parisCol - 1 >= 0)
                    {
                        parisCol--;
                    }
                }
                else if (command == "right")
                {
                    if (parisCol + 1 < matrix[parisRow].Length)
                    {
                        parisCol++;
                    }
                }

                energy--;
                if (matrix[parisRow][parisCol] == matrix[spartanRow][spartanCol])
                {
                    energy -= 2;
                    matrix[parisRow][parisCol] = '-';
                }
                else if (matrix[parisRow][parisCol] == matrix[helenaRow][helenaCol])
                {
                    matrix[parisRow][parisCol] = '-';
                    Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
                    break;
                }

                if (energy <= 0)
                {
                    Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
                    matrix[parisRow][parisCol] = 'X';
                    break;
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}