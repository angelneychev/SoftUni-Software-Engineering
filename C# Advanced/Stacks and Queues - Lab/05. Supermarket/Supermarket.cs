using System;
using System.Collections.Generic;

namespace _05._Supermarket
{
    public class Supermarket
    {
        static void Main()
        {

            var inputLine = Console.ReadLine();
            var nameQueue = new Queue<string>();

            while (inputLine != "End")
            {
                if (inputLine != "Paid")
                {
                    nameQueue.Enqueue(inputLine);
                    
                }
                else
                {
                    foreach (var item in nameQueue)
                    {
                        Console.WriteLine(item);
                    }
                    nameQueue.Clear();
                }

                inputLine = Console.ReadLine();
            }

            Console.WriteLine($"{nameQueue.Count} people remaining.");



            //int[] inputLine = Console.ReadLine()
            //    .Split()
            //    .Select(int.Parse).ToArray();
            //var evetQueue = new Queue<int>();

            //for (int i = 0; i < inputLine.Count(); i++)
            //{
            //    if (inputLine[i] % 2 == 0)
            //    {
            //        evetQueue.Enqueue(inputLine[i]);

            //    }

            //}
            //Console.Write(string.Join(", ", evetQueue));

        }
    }
}
