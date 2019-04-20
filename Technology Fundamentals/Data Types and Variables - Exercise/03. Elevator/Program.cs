using System;
// Data Types and Variables - Exercise
namespace _03._Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int elevatePersons = int.Parse(Console.ReadLine());
            int capacityPersons = int.Parse(Console.ReadLine());
            double courses = (double)elevatePersons / capacityPersons;

            Console.WriteLine(Math.Ceiling(courses));
        }
    }
}
