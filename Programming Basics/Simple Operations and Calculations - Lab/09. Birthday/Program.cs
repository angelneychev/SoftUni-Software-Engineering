using System;

namespace _09._Birthday
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = double.Parse(Console.ReadLine()); // дължина
            var w = double.Parse(Console.ReadLine()); // широчина
            var h = double.Parse(Console.ReadLine()); // Височина
            var propercents = double.Parse(Console.ReadLine()); // Процент
            var v = l * w * h; // обем на аквариума 
            v = v * 0.001; //конвертираме дециметри
            propercents = propercents * 0.01;
            var realV = v * (1 - propercents);
            Console.WriteLine($"{realV:F3}");
        }
    }
}
