﻿using System;

namespace _01._Personal_Titles
{
    class Program
    {
        static void Main(string[] args)
        {
            var age = double.Parse(Console.ReadLine());
            string sex = Console.ReadLine().ToLower();
            if (age >= 16)
            {
                if (sex == "m")
                {
                    Console.WriteLine("Mr.");
                }
                else if (sex == "f")
                {
                    Console.WriteLine("Ms.");
                }
            }
            else
            {
                if (sex == "m")
                {
                    Console.WriteLine("Master");
                }
                else if (sex == "f")
                {
                    Console.WriteLine("Miss");
                }
            }
        }
    }
}
