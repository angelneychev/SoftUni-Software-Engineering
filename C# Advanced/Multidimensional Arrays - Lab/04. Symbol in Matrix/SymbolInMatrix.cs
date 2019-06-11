using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _04._Symbol_in_Matrix
{
    public class SymbolInMatrix
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int rows = size; // размер на реда
            int cols = size; // размер на колоната

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string arr = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    // пълним са данни колоните
                    matrix[row, col] = arr[col];
                }
            }

            // тук е входа за символа който трябва да проверим
            char input = char.Parse(Console.ReadLine());
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (input == matrix[row, col])
                    {
                        Console.WriteLine($"({row}, {col})");
                        // ако има съвпадение разпечатва и продължава изпълнението
                        return;
                    }
                }
            }

            Console.WriteLine($"{input} does not occur in the matrix");
        }
    }
}