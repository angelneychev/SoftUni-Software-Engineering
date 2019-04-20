using System;
// Data Types and Variables - Exercise
namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int countKegs = int.Parse(Console.ReadLine());
            double volumeKeg = 0;
            string biggestKeg = String.Empty;


            for (int i = 0; i < countKegs; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                double verification = Math.PI * (radius * radius) * height;
                if (verification > volumeKeg)
                {
                    volumeKeg = verification;
                    biggestKeg = model;
                }
            }

            Console.WriteLine(biggestKeg);
        }
    }
}
