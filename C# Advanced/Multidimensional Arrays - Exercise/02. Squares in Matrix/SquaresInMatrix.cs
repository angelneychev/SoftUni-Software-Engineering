using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02._Squares_in_Matrix
{
    class SquaresInMatrix
    {
        static void Main()
        {
            int[] size = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int rows = size[0];
            int cols = size[1];
            string[,] matrix = new string[rows,cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ");
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int count = 0;
            for (int row = 0; row < rows-1; row++)
            {
                for (int col = 0; col < cols-1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] 
                        && matrix[row, col + 1] == matrix[row +1,col +1]
                        && matrix[row + 1, col + 1] == matrix[row +1, col]
                        )
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
