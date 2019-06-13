using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _06._Bomb_the_Basement
{
   public class BombTheBasement
    {
        static void Main()
        {
            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = size[0];
            int cols = size[1];

            int[,] matrix = new int[rows,cols];

            int[] bomb = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int bombRow = bomb[0];
            int bombCol = bomb[1];
            int radius = bomb[2];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    double distans = Math.Sqrt(Math.Pow(row - bombRow, 2) + Math.Pow(col - bombCol, 2));
                    if (distans <= radius)
                    {
                        matrix[row, col] = 1;
                    }
                }
            }

            int[][] secondMatrix = new int[cols][];

            for (int row = 0; row < cols; row++)
            {
                secondMatrix[row] = new int[rows];
                for (int col = 0; col < rows; col++)
                {
                    secondMatrix[row][col] = matrix[col,row];
                }

                secondMatrix[row] = secondMatrix[row].OrderByDescending(x => x).ToArray();
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row,col] = secondMatrix[col][row];
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
