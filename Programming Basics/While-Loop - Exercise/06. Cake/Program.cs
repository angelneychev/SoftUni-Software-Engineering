﻿using System;

namespace _06._Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int widthCake = int.Parse(Console.ReadLine());
            int lenthCake = int.Parse(Console.ReadLine());
            var wholeCake = widthCake * lenthCake;
            while (wholeCake >= 0)
            {
                string taken = Console.ReadLine();
                if (taken == "STOP")
                {
                    Console.WriteLine($"{wholeCake} pieces are left.");
                    return;
                }
                wholeCake = wholeCake - int.Parse(taken);
            }
            Console.WriteLine($"No more cake left! You need {Math.Abs(wholeCake)} pieces more.");
        }
    }
}
