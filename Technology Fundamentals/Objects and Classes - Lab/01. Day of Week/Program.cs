using System;
using System.Globalization;
//Objects and Classes - Lab
namespace _01._Day_of_Week_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            DateTime day = DateTime.ParseExact(input, "d-M-yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine(day.DayOfWeek);
        }
    }
}
