using System;
using System.Collections.Generic;
using System.Linq;
// Programming Fundamentals - Retake Exam - 10 January 2019 Part I
namespace _02._Santa_s_Gifts
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<int> hous = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int indexList = 0;

            for (int i = 1; i <= number; i++)
            {
                string[] command = Console.ReadLine().Split();

                switch (command[0])
                {
                    case "Forward":
                        int jumpStep = int.Parse(command[1]);
                        if (jumpStep < 0 || jumpStep + indexList >= hous.Count)
                        {
                            continue;
                        }
                        indexList += jumpStep;
                        hous.RemoveAt(indexList);
                        break;
                    case "Back":
                        int backStep = int.Parse(command[1]);
                        if (indexList - backStep < 0)
                        {
                            continue;
                        }
                        indexList -= backStep;
                        hous.RemoveAt(indexList);
                        break;
                    case "Gift":
                        int firstIndex = int.Parse(command[1]);
                        int secondIndex = int.Parse(command[2]);
                        if (firstIndex < 0 || firstIndex >= hous.Count)
                        {
                            continue;
                        }
                        hous.Insert(firstIndex, secondIndex);
                        indexList = firstIndex;
                        break;
                    case "Swap":
                        int indexOfFirst = int.Parse(command[1]);
                        int indexOfSecond = int.Parse(command[2]);
                        if (hous.Contains(indexOfFirst) && hous.Contains(indexOfSecond))
                        {
                            int indexFirst = hous.IndexOf(indexOfFirst);
                            int indexSecond = hous.IndexOf(indexOfSecond);

                            hous[indexFirst] = indexOfSecond;
                            hous[indexSecond] = indexOfFirst;
                        }
                        break;
                }
            }

            Console.WriteLine($"Position: {indexList}");
            Console.WriteLine(string.Join(", ", hous));
        }
    }
}
