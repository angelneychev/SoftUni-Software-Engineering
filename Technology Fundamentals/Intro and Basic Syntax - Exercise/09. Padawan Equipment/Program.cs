using System;
//Intro and Basic Syntax - Exercise
namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double.Parse(Console.ReadLine()); //Всички пари 
            int countOfStudents = int.Parse(Console.ReadLine()); //Брой на струдентите
            double priceOfLightsabers = double.Parse(Console.ReadLine()); // Цена на лазарен меч купуваме с 10% повече
            double priceOfRobes = double.Parse(Console.ReadLine()); // Цена на наметало
            double priceOfBelts = double.Parse(Console.ReadLine()); // цена на колана

            double sumSabre = (Math.Ceiling(countOfStudents * 0.10) + countOfStudents) * priceOfLightsabers;
            double sumRobes = priceOfRobes * countOfStudents;
            double sumBelts = (countOfStudents - (Math.Floor(countOfStudents / 6.00))) * priceOfBelts;

            double totalSum = sumSabre + sumRobes + sumBelts;
            double neededMoney = amountOfMoney - totalSum;
            if (neededMoney >= 0)
            {
                Console.WriteLine($"The money is enough - it would cost {totalSum:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {Math.Abs(neededMoney):f2}lv more.");
            }


        }
    }
}
