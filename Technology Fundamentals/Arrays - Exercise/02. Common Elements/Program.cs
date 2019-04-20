using System;
using System.Linq;
//Arrays - Exercise
namespace _02._Common_Elements
{
    class Program
    {
        static void Main()
        {

            string[] str1 = Console.ReadLine()
                .Split()
                .ToArray();
            string[] str2 = Console.ReadLine()
                .Split()
                .ToArray();

            for (int i = 0; i < str2.Length; i++)
            {
                for (int j = 0; j < str1.Length; j++)
                {
                    if (str2[i] == str1[j])
                    {
                        Console.Write(str2[i] + " ");
                    }
                }
            }


        }
    }
}
