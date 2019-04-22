using System;

namespace _01._Sum_Seconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            var seconds = num1 + num2 + num3;
            var minutes = 0;

            if (seconds > 59)
            {
                minutes++;
                seconds = seconds - 60;
            }
            if (seconds > 59)
            {
                minutes++;
                seconds = seconds - 60;
            }
            if (seconds < 10)
            {
                Console.WriteLine(minutes + ":" + "0" + seconds);
            }
            else
            {
                Console.WriteLine(minutes + ":" + seconds);
            }
        }
    }
}
