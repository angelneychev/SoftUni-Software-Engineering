using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sum_Matrix_Columns
{
    public class SumMatrixColumns
    {
        static void Main()
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] colElements = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }
            // сумираме по колони
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int sum = 0; // за да може всеки път сумата да се занулява
                // и да се сметне само сумата на колоната
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sum += matrix[row, col];
                }
                //печатаме резултата след сумирането на всяка колона
                Console.WriteLine(sum);
            }
        }
    }
}