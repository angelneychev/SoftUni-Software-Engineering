using System;

namespace _05._Time___15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            var num1 = int.Parse(Console.ReadLine());
            var num2 = int.Parse(Console.ReadLine());
            var hour = 0;
            var minutes = 0;

            if (num2 + 15 > 59 && num1 < 23)
            {
                hour = num1 + 1;
                minutes = (num2 + 15) - 60;
            }
            else if (num2 + 15 <= 59 && num1 < 23)
            {
                hour = num1;
                minutes = num2 + 15;
            }
            else if (num1 == 23 && num2 + 15 > 59)
            {
                hour = 0;
                minutes = (num2 + 15) - 60;
            }
            else if (num1 == 23 && num2 + 15 <= 59)
            {
                hour = num1;
                minutes = num2 + 15;
            }
            if (minutes < 10)
            {
                Console.WriteLine(hour + ":" + "0" + minutes);
            }
            else
            {
                Console.WriteLine(hour + ":" + minutes);
            }
        }
    }
}
