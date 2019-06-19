using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;

namespace _02._Excel_Functions
{
   public class ExcelFunctions
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            string[][] table = new string[rows][];

            for (int col = 0; col < rows; col++)
            {
                table[col] = Console.ReadLine()
                    .Split(", ")
                    .ToArray();
            }

            string[] commandAgrs = Console.ReadLine().Split();
            string command = commandAgrs[0];
            string header = commandAgrs[1];

            //така правим масив от матрицата
            int headerIndex = Array.IndexOf(table[0], header);
            if (command == "hide")
            {
                for (int row = 0; row < table.Length; row++)
                {
                    // копираме в списък цялата матрица и след това трием това което не ни трябва
                    List<string> lintToPrint = new List<string>(table[row]);

                 //   table[row].Where((x, i) => Array.IndexOf(x, i) != headerIndex);

                    lintToPrint.RemoveAt(headerIndex);
                //взимаме това до индекса
                 //   lintToPrint.AddRange(table[row].Take(headerIndex).ToList());
                 //скпиваме хедъра защото сме го взели от горе
                //    lintToPrint.AddRange(table[row].Skip(headerIndex+1));
                    Console.WriteLine(string.Join(" | ",lintToPrint));
                   // table[row] = lintToPrint.ToArray();
                }
            }
            else if (command == "sort")
            {
                //принтираме хедъра
                string[] headerRow = table[0];
                Console.WriteLine(string.Join(" | ",table[0]));

               table = table.OrderBy(x => x[headerIndex]).ToArray();

                foreach (var row in table)
                {
                    if (row !=headerRow)
                    {
                        Console.WriteLine(string.Join(" | ",row));
                    }
                }
            }
            else if (command == "filter")
            {
                string parameter = commandAgrs[2];
                string[] headerRow = table[0];
                Console.WriteLine(string.Join(" | ", table[0]));

                for (int i = 0; i < table.Length; i++)
                {
                    if (table[i][headerIndex] == parameter)
                    {
                        Console.WriteLine(string.Join(" | ", table[i]));
                    }
                }

            }
        }
    }
}
