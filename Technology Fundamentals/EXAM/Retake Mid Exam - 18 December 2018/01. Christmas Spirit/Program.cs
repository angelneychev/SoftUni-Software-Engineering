using System;

namespace _01._Christmas_Spirit
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int totalBudget = 0;
            int totalSpirit = 0;

            int ornament = 2;
            int skirt = 5;
            int garlands = 3;
            int lights = 15;

            for (int i = 1; i <= days; i++)
            {
                if (i % 11 == 0)
                {
                    quantity += 2;
                }
                if (i %2 ==0)
                {
                    totalBudget += ornament * quantity;
                    totalSpirit += 5;
                }

                if (i % 3 == 0)
                {
                    totalBudget += skirt * quantity;
                    totalBudget += garlands * quantity;
                    totalSpirit += 13;
                }

                if (i % 5 ==0)
                {
                    totalBudget += lights * quantity;
                    totalSpirit += 17;
                    if (i % 3 == 0)
                    {
                        totalSpirit += 30;
                    }
                }

                if (i % 10 == 0)
                {
                    totalBudget += skirt + garlands + lights;
                    totalSpirit -= 20;
                }
                if (i % 10 == 0 && days == i)
                {
                    totalSpirit -= 30;
                }

            }
            Console.WriteLine($"Total cost: {totalBudget}");
            Console.WriteLine($"Total spirit: {totalSpirit}");
        }
    }
}
