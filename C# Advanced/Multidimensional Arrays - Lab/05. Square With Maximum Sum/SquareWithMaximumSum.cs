using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _05._Square_With_Maximum_Sum
{
    public class SquareWithMaximumSum
    {
        static void Main()
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            // създаваме редове и колони на матрицата
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] colElements = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            int maxSum = int.MinValue;
            int currentRow = -1;
            int currentCol = -1;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    var sumSquare = matrix[row, col] + matrix[row + 1, col] + matrix[row + 1, col + 1] +
                                    matrix[row, col + 1];
                    if (sumSquare > maxSum)
                    {
                        maxSum = sumSquare;
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[currentRow, currentCol]} {matrix[currentRow, currentCol + 1]}");
            Console.WriteLine($"{matrix[currentRow + 1, currentCol]} {matrix[currentRow + 1, currentCol + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}