using System;
using System.Xml.Schema;
//Intro and Basic Syntax - Exercise
namespace _10._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {

            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());
            int count = 0;
            double sum = 0;
            for (int i = 1; i <= lostGamesCount; i++)
            {
                bool destroyHeadset = false;
                bool destroyMouse = false;
                if (i % 2 == 0)
                {
                    sum += headsetPrice;
                    destroyHeadset = true;
                }
                if (i % 3 == 0)
                {
                    sum += mousePrice;
                    destroyMouse = true;
                }
                if (destroyHeadset && destroyMouse)
                {
                    sum += keyboardPrice;
                    count++;
                }
                if (count == 2)
                {
                    sum += displayPrice;
                    count = 0;
                }
            }
            Console.WriteLine($"Rage expenses: {sum:f2} lv.");

        }
    }
}
