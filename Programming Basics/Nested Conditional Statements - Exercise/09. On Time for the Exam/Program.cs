using System;

namespace _09._On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinute = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMinute = int.Parse(Console.ReadLine());

            int examTotalMinutes = (examHour * 60) + examMinute;
            int arrivalTotalMinutes = (arrivalHour * 60) + arrivalMinute;

            int value = examTotalMinutes - arrivalTotalMinutes;

            if (value >= 0 && value <= 30)
            {
                Console.WriteLine("On time");
            }
            else if (value > 30)
            {
                Console.WriteLine("Early");
            }
            else if (value < 0)
            {
                Console.WriteLine("Late");
            }

            if (value < 60 && value > 0)
            {
                Console.WriteLine($"{value} minutes before the start");
            }
            else if (value >= 60)
            {
                if ((value % 60) >= 10)
                {
                    Console.WriteLine($"{value / 60}:{value % 60} hours before the start");
                }
                else
                {
                    Console.WriteLine($"{value / 60}:0{value % 60} hours before the start");
                }
            }
            else if (value > -60 && value < 0)
            {
                Console.WriteLine($"{Math.Abs(value)} minutes after the start");
            }
            else if (value <= -60)
            {
                if ((value % -60) <= -10)
                {
                    Console.WriteLine($"{Math.Abs(value / -60)}:{Math.Abs(value % -60)} hours after the start");
                }
                else
                {
                    Console.WriteLine($"{Math.Abs(value / -60)}:0{Math.Abs(value % -60)} hours after the start");
                }
            }
        }
    }
}
