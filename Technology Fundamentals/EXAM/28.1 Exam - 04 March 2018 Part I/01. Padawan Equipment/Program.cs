using System;

namespace _01._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double priceOfLightsabers = double.Parse(Console.ReadLine());
            double priceOfRobes = double.Parse(Console.ReadLine());
            double priceOfBelts = double.Parse(Console.ReadLine());
            int freeBelts = 0;

            if (countOfStudents >= 6)
            {
                freeBelts = countOfStudents / 6;
            }

            double sumLightsabers = priceOfLightsabers * (Math.Ceiling(countOfStudents * 0.1) + countOfStudents);
            double sumRobes = (priceOfRobes * countOfStudents);
            double sumBelts = priceOfBelts * (countOfStudents - freeBelts);

            double sum = sumLightsabers + sumRobes + sumBelts;

            double diff = sum - amountOfMoney;
            if (diff <= 0)
            {
                Console.WriteLine($"The money is enough - it would cost {sum:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {Math.Abs(diff):f2}lv more.");
            }
        }
    }
}
