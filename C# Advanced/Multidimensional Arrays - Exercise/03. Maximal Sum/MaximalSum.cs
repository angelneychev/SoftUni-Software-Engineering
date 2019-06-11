using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximal_Sum
{
    public class MaximalSum
    {
        static void Main()
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = size[0];
            var cols = size[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] colElement = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElement[col];
                }
            }

            int maxSum = int.MinValue;
            int selectedRow = -1;
            int selectedCol = -1;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] 
                              + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] 
                              + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        selectedRow = row;
                        selectedCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int row = selectedRow; row < selectedRow + 3; row++)
            {
                for (int col = selectedCol; col < selectedCol + 3; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}