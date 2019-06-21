using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace ExcelFunctions
{
    public class ExcelFunctions
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            string[][] matrix = new string[rows][];

            for (int col = 0; col < rows; col++)
            {
                string[] input = Console.ReadLine().Split(", ").ToArray();
                matrix[col] = input;
            }

            string[] commands = Console.ReadLine().Split().ToArray();
            string command = commands[0];
            string header = commands[1];

            int headerIndex = Array.IndexOf(matrix[0], header);

            if (command == "hide")
            {
                for (int row = 0; row < matrix.Length; row++)
                {
                    List<string> printList = new List<string>(matrix[row]);

                    printList.RemoveAt(headerIndex);
                    Console.WriteLine(string.Join(" | ", printList));
                }
            }
            else if (command == "sort")
            {
                string[] headerRow = matrix[0];
                Console.WriteLine(string.Join(" | ", headerRow));
                // сортирам матрицара
                matrix = matrix.OrderBy(x => x[headerIndex]).ToArray();
                foreach (var row in matrix)
                {
                    if (row != headerRow)
                    {
                        Console.WriteLine(string.Join(" | ", row));
                    }
                }
            }
            else if (command == "filter")
            {
                string valueCol = commands[2];
                string[] headerRow = matrix[0];
                Console.WriteLine(string.Join(" | ", matrix[0]));
                for (int row = 0; row < matrix.Length; row++)
                {
                    if (matrix[row][headerIndex] == valueCol)
                    {
                        Console.WriteLine(string.Join(" | ", matrix[row]));
                    }
                }
            }
        }
    }
}