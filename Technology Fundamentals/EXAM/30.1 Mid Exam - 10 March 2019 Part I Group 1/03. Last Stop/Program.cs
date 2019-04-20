using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Last_Stop
{//изпит
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputLine = Console.ReadLine().Split().Select(int.Parse).ToList();

            string[] command = Console.ReadLine().Split();

            while (command[0] != "END")
            {
                if (command[0] == "Change")
                {
                    int paintingNumber = int.Parse(command[1]);
                    int changedNumber = int.Parse(command[2]);
                    int left = inputLine.IndexOf(paintingNumber);
                    if (inputLine.Contains(paintingNumber))
                    {
                        inputLine[left] = changedNumber;
                    }
                }
                else if (command[0] == "Hide")
                {
                    if (inputLine.Contains(int.Parse(command[1])))
                    {
                        inputLine.Remove(int.Parse(command[1]));
                    }
                }
                else if (command[0] == "Switch")
                {
                    int paintingNumber = int.Parse(command[1]);
                    int paintingNumber2 = int.Parse(command[2]);
                    int left = inputLine.IndexOf(paintingNumber);
                    int right = inputLine.IndexOf(paintingNumber2);

                    if (inputLine.Contains(paintingNumber) && inputLine.Contains(paintingNumber2))
                    {
                        inputLine[left] = paintingNumber2;
                        inputLine[right] = paintingNumber;
                    }
                }
                else if (command[0] == "Insert")
                {
                    int place = int.Parse(command[1]);
                    int paintingNumber = int.Parse(command[2]);
                    if (place >= 0 && place < inputLine.Count)
                    {
                        inputLine.Insert(place + 1, paintingNumber);
                    }

                }
                else if (command[0] == "Reverse")
                {
                    inputLine.Reverse();
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", inputLine));
        }
    }
}
