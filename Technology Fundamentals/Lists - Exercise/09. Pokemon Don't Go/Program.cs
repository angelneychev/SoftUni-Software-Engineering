using System;
using System.Collections.Generic;
using System.Linq;
//Lists - Exercise
namespace _09._Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                        .Split()
                        .Select(int.Parse)
                        .ToList();
            // List<int> numbers = new List<int>(){4, 5, 3};
            int lineIndex = int.Parse(Console.ReadLine());
            int sum = 0;
            int numberValueEdit = 0;
            while (true)
            {

                if (lineIndex < 0)
                {
                    int copyNumber = numbers.Count - 1;
                    sum += numbers[copyNumber];
                    numbers[0] = numbers[copyNumber];
                    numberValueEdit = numbers[0];
                }
                else if (lineIndex > numbers.Count - 1)
                {
                    int copyNumber = numbers[0];
                    numbers[numbers.Count - 1] = copyNumber;
                    sum += numbers[0];
                    numberValueEdit = numbers[0];
                }
                else if (lineIndex >= 0 && lineIndex <= numbers.Count - 1)
                {
                    numberValueEdit = numbers[lineIndex];
                    sum += numberValueEdit;
                    numbers.RemoveAt(lineIndex);
                }
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] <= numberValueEdit)
                    {
                        numbers[i] += numberValueEdit;
                    }
                    else if (numbers[i] > numberValueEdit)
                    {
                        numbers[i] -= numberValueEdit;
                    }
                }
                if (numbers.Count == 0)
                {
                    break;
                }
                lineIndex = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(sum);
        }
    }
}
