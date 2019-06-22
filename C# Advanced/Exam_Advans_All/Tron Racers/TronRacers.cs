using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tron_Racers
{
    class TronRacers
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            char[][] matrix = new char[rows][];
            int fRow = -1;
            int fCol = -1;
            int sRow = -1;
            int sCol = -1;

            for (int col = 0; col < rows; col++)
            {
                matrix[col] = Console.ReadLine().ToCharArray();
                if (matrix[col].Contains('f'))
                {
                    int indexRow = Array.IndexOf(matrix[col], 'f');
                    fRow = col;
                    fCol = indexRow;
                }

                if (matrix[col].Contains('s'))
                {
                    int indexRow = Array.IndexOf(matrix[col], 's');
                    sRow = col;
                    sCol = indexRow;
                }
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split();
                string firstPlayer = commands[0];
                string secondPlayer = commands[1];

                if (firstPlayer == "down")
                {
                    fRow++;
                    if (fRow == matrix.Length)
                    {
                        fRow = 0;
                    }
                }
                else if (firstPlayer == "up")
                {
                    fRow--;
                    if (fRow < 0)
                    {
                        fRow = matrix.Length - 1;
                    }
                }
                else if (firstPlayer == "left")
                {
                    fCol--;
                    if (fCol < 0)
                    {
                        fCol = matrix[fRow].Length - 1;
                    }
                }
                else if (firstPlayer == "right")
                {
                    fCol++;
                    if (fCol == matrix[fRow].Length)
                    {
                        fCol = 0;
                    }
                }

                if (matrix[fRow][fCol] == 's')
                {
                    matrix[fRow][fCol] = 'x';
                    break;
                }
                else
                {
                    matrix[fRow][fCol] = 'f';
                }

                ///
                if (secondPlayer == "down")
                {
                    sRow++;
                    if (sRow == matrix.Length)
                    {
                        sRow = 0;
                    }
                }
                else if (secondPlayer == "up")
                {
                    sRow--;
                    if (sRow < 0)
                    {
                        sRow = matrix.Length - 1;
                    }
                }
                else if (secondPlayer == "left")
                {
                    sCol--;
                    if (sCol < 0)
                    {
                        sCol = matrix[sRow].Length - 1;
                    }
                }
                else if (secondPlayer == "right")
                {
                    sCol++;
                    if (sCol == matrix[sRow].Length)
                    {
                        sCol = 0;
                    }
                }

                if (matrix[sRow][sCol] == 'f')
                {
                    matrix[sRow][sCol] = 'x';
                    break;
                }
                else
                {
                    matrix[sRow][sCol] = 's';
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}