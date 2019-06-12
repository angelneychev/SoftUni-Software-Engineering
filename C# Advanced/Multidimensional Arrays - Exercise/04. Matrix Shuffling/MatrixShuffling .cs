using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace _04._Matrix_Shuffling
{
   public class MatrixShuffling
    {
        static void Main()
        {
            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = size[0];
            int cols = size[1];

            string[,] matrix = new string[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                string[] colElements = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] tokens = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] != "swap" || tokens.Length !=5)
                {
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine();
                    continue;
                }

                int x1 = int.Parse(tokens[1]);
                int y1 = int.Parse(tokens[2]);
                int x2 = int.Parse(tokens[3]);
                int y2 = int.Parse(tokens[4]);
                if (x1<0 || x1 >=rows || y1<0 || y1 >= cols ||
                x2 < 0 || x2 >= rows || y2 < 0 || y2 >= cols)
                {
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine();
                    continue;
                }

                var firstElement = matrix[x1,y1];
                var secondElement = matrix[x2,y2];

                matrix[x1, y1] = secondElement;
                matrix[x2, y2] = firstElement;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write(matrix[row,col] + " ");
                    }

                    Console.WriteLine();
                }

                input = Console.ReadLine();
            }
        }
    }
}
