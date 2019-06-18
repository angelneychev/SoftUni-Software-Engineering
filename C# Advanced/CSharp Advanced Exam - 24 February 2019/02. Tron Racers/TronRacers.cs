using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Tron_Racers
{
  public  class TronRacers
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
            string[] commands = Console.ReadLine().Split();
            while (commands[0] !="")
            {
                string firstPlayer = commands[0];
                string secondPlayer = commands[1];

                switch (firstPlayer)
                {
                    case "up":
                        fRow--;
                        break;
                    case "down":
                        fRow++;
                        break;
                    case "left":
                        fCol--;
                        break;
                    case "right":
                        fCol++;
                        break;
                    default:
                        break;
                }
                switch (secondPlayer)
                {
                    case "up":
                        sRow--;
                        break;
                    case "down":
                        sRow++;
                        break;
                    case "left":
                        sCol--;
                        break;
                    case "right":
                        sCol++;
                        break;
                    default:
                        break;
                }

                if (isInside(matrix,fRow,fCol))
                {
                    if (matrix[fRow][fCol] != 's')
                    {
                        matrix[fRow][fCol] = 'f';
                    }
                    else
                    {
                        matrix[fRow][fCol] = 'x';
                        break;
                    }
                    
                }
                if (isInside(matrix, sRow, sCol))
                {
                    if (matrix[sRow][sCol] !='f')
                    {
                        matrix[sRow][sCol] = 's';
                    }
                    else
                    {
                        matrix[fRow][fCol] = 'x';
                        break;
                    }
                }
                commands = Console.ReadLine().Split();
            }
            
            //принтирам матрицата
            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join("",item));
            }
        }

        private static bool isInside(char[][] matrix, int row, int col)
        {
            return row >= 0
                   && row < matrix.Length
                   && col >= 0
                   && col < matrix[row].Length;
        }
    }
}
