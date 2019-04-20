using System;
using System.Numerics;
// Data Types and Variables - Exercise
namespace _11._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberSnowballs = int.Parse(Console.ReadLine());
            BigInteger value1 = -1;
            string result = string.Empty;

            for (int i = 0; i < numberSnowballs; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());
                BigInteger value = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);
                if (value > value1)
                {
                    result = ($"{snowballSnow} : {snowballTime} = {value} ({snowballQuality})");
                    value1 = value;
                }

            }
            Console.WriteLine(result);
        }
    }
}
