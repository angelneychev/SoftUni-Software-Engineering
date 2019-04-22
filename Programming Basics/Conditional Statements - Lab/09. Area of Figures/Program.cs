using System;

namespace _09._Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            double sum = 0;

            if (type == "square")
            {
                var a = double.Parse(Console.ReadLine());
                sum = a * a;
            }
            else if (type == "rectangle")
            {
                var a = double.Parse(Console.ReadLine());
                var b = double.Parse(Console.ReadLine());
                sum = a * b;
            }
            else if (type == "circle")
            {
                var r = double.Parse(Console.ReadLine());
                sum = Math.PI * r * r;
            }
            else if (type == "triangle")
            {
                var a = double.Parse(Console.ReadLine());
                var h = double.Parse(Console.ReadLine());
                sum = (a * h) / 2;
            }
            Console.WriteLine(sum);
        }
    }
}
