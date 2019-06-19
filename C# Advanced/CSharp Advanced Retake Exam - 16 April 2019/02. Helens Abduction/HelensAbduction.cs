using System;
using System.Linq;

namespace _02._Helens_Abduction
{
    public class HelensAbduction
    {
        private static void Main()
        {
            var energy = int.Parse(Console.ReadLine());
            var rows = int.Parse(Console.ReadLine());
            var matrix = new char[rows][];
            var parisRow = -1;
            var parisCol = -1;
            var helenaRow = -1;
            var helenaCol = -1;
            for (var col = 0; col < rows; col++)
            {
                var input = Console.ReadLine().ToCharArray();
                matrix[col] = input;
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
            var commands = Console.ReadLine().Split(" ").ToArray();
            while (true)
            {
                var commandParis = commands[0];
                var enemyRow = int.Parse(commands[1]);
                var enemyCol = int.Parse(commands[2]);

                matrix[enemyRow][enemyCol] = 'S';

                if (commandParis == "up")
                {
                    if (parisRow - 1 >= 0)
                    {
                        parisRow--;
                    }
                    energy--;

                }
                else if (commandParis == "down")
                {
                    if (parisRow + 1 < matrix[parisCol].Length)
                    {
                        parisRow++;
                    }
                    energy--;
                }
                else if (commandParis == "left")
                {
                    if (parisCol - 1 >= 0)
                    {
                        parisCol--;
                    }
                    energy--;
                }
                else if (commandParis == "right")
                {
                    if (parisCol + 1 < matrix[parisRow].Length)
                    {
                        parisCol++;
                    }
                    energy--;
                }
                if (matrix[parisRow][parisCol] == 'S')
                {
                    energy -= 2;
                    matrix[parisRow][parisCol] = '-';
                }
                if (matrix[parisRow][parisCol] == 'H')
                {
                    matrix[parisRow][parisCol] = '-';
                    Console.Write("Paris has successfully abducted Helen! ");
                    Console.WriteLine($"Energy left: {energy}");
                    break;
                }

                if (energy <= 0)
                {
                    Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
                    matrix[parisRow][parisCol] = 'X';
                    break;
                }

                commands = Console.ReadLine().Split(" ");
            }

            foreach (var row in matrix) Console.WriteLine(string.Join("", row));
        }
    }
}