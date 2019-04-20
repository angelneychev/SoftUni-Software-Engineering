using System;
using System.Collections.Generic;
//Intro and Basic Syntax - Exercise
namespace _06._Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            int convertNumber = inputNumber;
            int sum = 0;

            while (convertNumber > 0)
            {
                int lastDigit = convertNumber % 10; // взимама последната цифра

                convertNumber /= 10; // махам последната цифра на числото

                int curentFactorial = 1; // факториел от 1-ца е 1, така е прието и за for цикъла започва от 2

                for (int i = 2; i <= lastDigit; i++)
                {
                    curentFactorial *= i;// пресмятам факториела на всяко едно число
                }
                sum += curentFactorial; // сумирам факториелите на числата
            }

            if (sum == inputNumber) // проверка дали сумата на факториелите е = на подадения вход
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
