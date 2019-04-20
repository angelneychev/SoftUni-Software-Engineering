using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced
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
                string[] token = line.Split();
                switch (token[0])
                {
                    case "Contains":
                        int containsNumber = int.Parse(token[1]);
                        var getContainsNumber = numbers.Contains(containsNumber);
                        if (getContainsNumber)
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "PrintEven":
                        var printEvenNumber = numbers.Where(x => x % 2 == 0);
                        Console.WriteLine(string.Join(" ", printEvenNumber));
                        break;
                    case "PrintOdd":
                        var printOddNumber = numbers.Where(x => x % 2 != 0);
                        Console.WriteLine(string.Join(" ", printOddNumber));
                        break;
                    case "GetSum":
                        var getSum = numbers.Sum();
                        Console.WriteLine(getSum);
                        break;
                    case "Filter":
                        string condition = token[1];
                        var numberToInsert = int.Parse(token[2]);
                        IEnumerable<int> printCondition = null;
                        if (condition == ">")
                        {
                            printCondition = numbers.Where(x => x > numberToInsert);
                            // Console.WriteLine(string.Join(" ", printCondition));
                        }
                        else if (condition == ">=")
                        {
                            printCondition = numbers.Where(x => x >= numberToInsert);
                            //Console.WriteLine(string.Join(" ", printCondition));
                        }
                        else if (condition == "<")
                        {

                            printCondition = numbers.Where(x => x < numberToInsert);
                            //  Console.WriteLine(string.Join(" ", printCondition));
                        }
                        else if (condition == "<=")
                        {
                            printCondition = numbers.Where(x => x <= numberToInsert);
                            // Console.WriteLine(string.Join(" ", printCondition));
                        }
                        Console.WriteLine(string.Join(" ", printCondition));
                        break;
                }
                switch (token[0])
                {
                    case "Add":
                        int numerToAdd = int.Parse(token[1]);
                        numbers.Add(numerToAdd);
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                    case "Remove":
                        int numberRemove = int.Parse(token[1]);
                        numbers.Remove(numberRemove);
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                    case "RemoveAt":
                        int indexRemove = int.Parse(token[1]);
                        numbers.RemoveAt(indexRemove);
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                    case "Insert":
                        int numberToInsert = int.Parse(token[1]);
                        int indexToInsert = int.Parse(token[2]);
                        numbers.Insert(indexToInsert, numberToInsert);
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                }

            }
        }
    }
}
