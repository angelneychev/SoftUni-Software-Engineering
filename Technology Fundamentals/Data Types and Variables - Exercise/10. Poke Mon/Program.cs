using System;
// Data Types and Variables - Exercise
namespace _10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstLineN = double.Parse(Console.ReadLine());
            double secondLineM = double.Parse(Console.ReadLine());
            int thirdLineY = int.Parse(Console.ReadLine());
            int count = 0;
            double transfer = firstLineN / 2;

            while (true)
            {
                firstLineN -= secondLineM;
                count++;
                if (thirdLineY != 0)
                {
                    if (transfer == firstLineN)
                    {
                        firstLineN /= thirdLineY;
                    }

                    if (firstLineN < secondLineM)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(Math.Floor(firstLineN));
            Console.WriteLine(count);
        }
    }
}
