﻿using System;
//Programming Fundamentals - Mid Exam - 18 December 2018
namespace _01._Christmas_Spirit
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int totalSpirit = 0;
            int budget = 0;

            int ornamentSet = 2;
            int treeSkirt = 5;
            int treeGarlands = 3;
            int treeLights = 15;

            for (int i = 1; i <= days; i++)
            {
                if (i % 11 == 0)
                {
                    quantity += 2;
                }
                if (i % 2 == 0)
                {
                    budget += ornamentSet * quantity;
                    totalSpirit += 5;
                }
                if (i % 3 == 0)
                {
                    budget += treeSkirt * quantity;
                    budget += treeGarlands * quantity;
                    totalSpirit += 13;
                }
                if (i % 5 == 0)
                {
                    budget += treeLights * quantity;
                    totalSpirit += 17;

                    if (i % 3 == 0)
                    {
                        totalSpirit += 30;
                    }

                }
                if (i % 10 == 0)
                {
                    budget += treeSkirt + treeGarlands + treeLights;
                    totalSpirit -= 20;

                }
                if (i % 10 == 0 && days == i)
                {
                    totalSpirit -= 30;
                }

            }
            Console.WriteLine($"Total cost: {budget}");
            Console.WriteLine($"Total spirit: {totalSpirit}");
        }
    }
}
