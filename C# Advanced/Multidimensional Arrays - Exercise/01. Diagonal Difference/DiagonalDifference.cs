using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Diagonal_Difference
{
   public class DiagonalDifference
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int rows = size;
            int cols = size;
            int[,] matrix = new int[rows,cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] colElement = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElement[col];
                }

            }

            int sumLeft = 0;
            int sumRight = 0;
            int totalSum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sumLeft += matrix[row, row];
            }

            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                sumRight += matrix[row, size - row - 1];
            }

            totalSum = sumLeft - sumRight;
            Console.WriteLine(Math.Abs(totalSum));
        }
    }
}
