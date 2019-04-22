using System;

namespace _01._Point_on_Rectangle_Border
{
    class Program
    {
        static void Main(string[] args)
        {
            var x1 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());
            var x2 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());
            var x = double.Parse(Console.ReadLine());
            var y = double.Parse(Console.ReadLine());

            var leftBorder = (x == x1) && (y >= y1) && (y <= y2);
            var rightBorder = (x == x2) && (y >= y1) && (y <= y2);
            var upBorder = (y == y1) && (x >= x1) && (x <= x2);
            var dounBorder = (y == y2) && (x >= x1) && (x <= x2);

            if (leftBorder || rightBorder || upBorder || dounBorder)
            {
                Console.WriteLine("Border");
            }
            else
            {
                Console.WriteLine("Inside / Outside");
            }
        }
    }
}
