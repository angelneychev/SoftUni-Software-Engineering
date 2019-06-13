using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _05._Snake_Moves
{
 public   class SnakeMoves
    {
        static void Main()
        {
            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = size[0];
            int cols = size[1];

            char[,] matrix = new char[rows, cols];

            var snakeStr = Console.ReadLine().ToCharArray();
            Queue<char> snakeQueue = new Queue<char>(snakeStr);
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                   char charToAdd = snakeQueue.Dequeue();
                   matrix[row, col] = charToAdd;
                   snakeQueue.Enqueue(charToAdd);
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
