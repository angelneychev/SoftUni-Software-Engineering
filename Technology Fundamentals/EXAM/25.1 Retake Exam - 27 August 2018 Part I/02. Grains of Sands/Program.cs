using System;
using System.Collections.Generic;
using System.Linq;
//Programming Fundamentals - Retake Exam - 27 August 2018 Part I
namespace _02._Grains_of_Sands
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputLine = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string[] command = Console.ReadLine().Split();
                if (command[0] == "Mort")
                {
                    break;
                }

                if (command[0] == "Add")
                {
                    inputLine.Add(int.Parse(command[1]));
                }
                else if (command[0] == "Remove")
                {
                    if (inputLine.Contains(int.Parse(command[1])))
                    {
                        inputLine.Remove(int.Parse(command[1]));
                    }
                    else if (int.Parse(command[1]) > inputLine.Count || int.Parse(command[1]) < 0)
                    {
                        continue;
                    }
                    else
                    {
                        inputLine.RemoveAt(int.Parse(command[1]));
                    }
                }
                else if (command[0] == "Replace")
                {
                    if (inputLine.Contains(int.Parse(command[1])))
                    {
                        int findNumber = int.Parse(command[1]);
                        int replaceNumber = int.Parse(command[2]);
                        int indexValue = inputLine.IndexOf(findNumber);
                        inputLine[indexValue] = replaceNumber;
                    }
                }
                else if (command[0] == "Increase")
                {
                    if (inputLine.Contains(int.Parse(command[1])))
                    {
                        for (int i = 0; i < inputLine.Count; i++)
                        {
                            inputLine[i] += int.Parse(command[1]);
                        }
                    }
                    else
                    {
                        int upNumber = inputLine[inputLine.Count - 1];
                        for (int i = 0; i < inputLine.Count; i++)
                        {
                            inputLine[i] += upNumber;
                        }
                    }
                }
                else if (command[0] == "Collapse")
                {
                    inputLine.RemoveAll(x => x < int.Parse(command[1]));
                }

            }

            Console.WriteLine(string.Join(" ", inputLine));
        }
    }
}
