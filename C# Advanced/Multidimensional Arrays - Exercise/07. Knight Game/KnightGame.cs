using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _07._Knight_Game
{
   public class KnightGame
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            
            char[][] matrix = new char[n][];

            for (int row = 0; row < n; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();

            }

            int removeHorses = 0;

            while (true)
            {
                int knightRow = -1;
                int knightCol = -1;
                int maxAttacked = 0;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (matrix[row][col] == 'K')
                        {
                            int tempAttack = CountAttacks(matrix, row, col);

                            if (tempAttack > maxAttacked)
                            {
                                maxAttacked = tempAttack;
                                knightRow = row;
                                knightCol = col;
                            }
                        }
                    }
                }

                if (maxAttacked > 0)
                {
                    matrix[knightRow][knightCol] = '0';
                    removeHorses++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(removeHorses);
        }

        private static int CountAttacks(char[][] matrix, int row, int col)
        {
            int attacks = 0;
            if (isInMatrix(row - 1, col - 2, matrix.Length) && matrix[row - 1][col - 2] == 'K')
            {
                attacks++;
            }

            if (isInMatrix(row - 1, col + 2, matrix.Length) && matrix[row - 1][col + 2] == 'K')
            {
                attacks++;
            }

            if (isInMatrix(row + 1, col - 2, matrix.Length) && matrix[row + 1][col - 2] == 'K')
            {
                attacks++;
            }

            if (isInMatrix(row + 1, col + 2, matrix.Length) && matrix[row + 1][col + 2] == 'K')
            {
                attacks++;
            }

            if (isInMatrix(row - 2, col - 1, matrix.Length) && matrix[row - 2][col - 1] == 'K')
            {
                attacks++;
            }

            if (isInMatrix(row - 2, col + 1, matrix.Length) && matrix[row - 2][col + 1] == 'K')
            {
                attacks++;
            }

            if (isInMatrix(row + 2, col - 1, matrix.Length) && matrix[row + 2][col - 1] == 'K')
            {
                attacks++;
            }

            if (isInMatrix(row + 2, col + 1, matrix.Length) && matrix[row + 2][col + 1] == 'K')
            {
                attacks++;
            }

            return attacks;
        }

        private static bool isInMatrix(int row, int col, int length)
        {
            return row >= 0 && row < length && col >= 0 && col < length;
        }
    }
}
