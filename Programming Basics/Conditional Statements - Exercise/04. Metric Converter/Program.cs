using System;

namespace _04._Metric_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = double.Parse(Console.ReadLine());
            string me1 = Console.ReadLine();
            string me2 = Console.ReadLine();

            if (me1 == "m")
            {
                num = num / 1;
            }
            else if (me1 == "mm")
            {
                num = num / 1000;
            }
            else if (me1 == "cm")
            {
                num = num / 100;
            }
            else if (me1 == "mi")
            {
                num = num / 0.000621371192;
            }
            else if (me1 == "in")
            {
                num = num / 39.3700787;
            }
            else if (me1 == "km")
            {
                num = num / 0.001;
            }
            else if (me1 == "ft")
            {
                num = num / 3.2808399;
            }
            else if (me1 == "yd")
            {
                num = num / 1.0936133;
            }
            //=============
            if (me2 == "m")
            {
                num = num * 1;
            }
            else if (me2 == "mm")
            {
                num = num * 1000;
            }
            else if (me2 == "cm")
            {
                num = num * 100;
            }
            else if (me2 == "mi")
            {
                num = num * 0.000621371192;
            }
            else if (me2 == "in")
            {
                num = num * 39.3700787;
            }
            else if (me2 == "km")
            {
                num = num * 0.001;
            }
            else if (me2 == "ft")
            {
                num = num * 3.2808399;
            }
            else if (me2 == "yd")
            {
                num = num * 1.0936133;
            }
            Console.WriteLine($"{num:F8}");
        }
    }
}
