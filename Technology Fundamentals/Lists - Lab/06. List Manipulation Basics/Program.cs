using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "end")
                {
                    break;
                }
                string[] tokens = line.Split();

                switch (tokens[0])
                {
                    case "Add":
                        int numerToAdd = int.Parse(tokens[1]);
                        numbers.Add(numerToAdd);
                        break;
                    case "Remove":
                        int numberRemove = int.Parse(tokens[1]);
                        numbers.Remove(numberRemove);
                        break;
                    case "RemoveAt":
                        int indexRemove = int.Parse(tokens[1]);
                        numbers.RemoveAt(indexRemove);
                        break;
                    case "Insert":
                        int numberToInsert = int.Parse(tokens[1]);
                        int indexToInsert = int.Parse(tokens[2]);
                        numbers.Insert(indexToInsert, numberToInsert);
                        break;
                }

            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
