using System;
using System.Collections.Generic;
using System.Linq;
//Arrays - Lab
namespace _08._Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] sequence = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            while (sequence.Length > 1)
            {
                int[] condensedArray = new int[sequence.Length - 1];
                for (int i = 0; i < sequence.Length - 1; i++)
                {
                    condensedArray[i] = sequence[i] + sequence[i + 1];
                }

                sequence = condensedArray;
            }
            Console.WriteLine(sequence[0]);
        }
    }
}
