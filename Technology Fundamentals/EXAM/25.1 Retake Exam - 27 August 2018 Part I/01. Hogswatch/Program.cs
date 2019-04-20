using System;
//Programming Fundamentals - Retake Exam - 27 August 2018 Part I
namespace _01._Hogswatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int homesToVisit = int.Parse(Console.ReadLine());
            int initialPresents = int.Parse(Console.ReadLine());
            int presentsAll = initialPresents;
            int additionalPresentsTaken = 0;
            int timesBack = 0;
            for (int i = 1; i <= homesToVisit; i++)
            {
                //({initialPresents} / {visitedHomes})
                //* {remainingHomes} + {additionalPresents}

                int visitedHomes = i;
                int remainingHomes = homesToVisit - i;
                int presents = int.Parse(Console.ReadLine());


                if (presentsAll - presents < 0)
                {
                    int additionalPresents = Math.Abs(presentsAll - presents);
                    int temp = (initialPresents / visitedHomes)
                               * remainingHomes + additionalPresents;
                    timesBack++;
                    additionalPresentsTaken += temp;
                    presentsAll += temp;
                    presentsAll -= presents;
                }
                else
                {
                    presentsAll -= presents;
                }
            }

            if (timesBack == 0)
            {
                Console.WriteLine($"{presentsAll}");
            }
            else
            {
                Console.WriteLine($"{timesBack}");
                Console.WriteLine($"{additionalPresentsTaken}");
            }
        }
    }
}